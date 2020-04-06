using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class GOAPAgent : MonoBehaviour
{
    private FSM stateMachine;

	private FSM.FSMState idleState;
	private FSM.FSMState moveToState;
	private FSM.FSMState performActionState;

	private HashSet<GOAP.Action> availableActions = null;
	public Queue<GOAP.Action> currentActions = null;
    public GOAP.Action[] actions = null;

    private GOAP.Interface dataProvider;

    private GOAP.Planner planner;

    void Start()
    {
        stateMachine = new FSM();
        availableActions = new HashSet<GOAP.Action>();
        currentActions = new Queue<GOAP.Action>();
        planner = new GOAP.Planner();
        
        FindDataProvider();
        CreateIdleState();
        CreateMoveToState();
        CreatePerformActionState();
		stateMachine.PushState(idleState);
        LoadActions();
    }

    void Update()
    {
        stateMachine.Update(gameObject);
    }

    public void AddAction(GOAP.Action action)
    {
        _ = availableActions.Add(action);
    }
    public void RemoveAction(GOAP.Action action)
    {
        _ = availableActions.Remove(action);
    }

	public GOAP.Action GetAction(Type action)
	{
		foreach (GOAP.Action a in availableActions)
		{
			if (a.GetType().Equals(action))
			{
				return a;
			}
		}
		return null;
	}
    
    private bool HasActionPlan()
    {
        return currentActions.Count > 0;
    }

    private void CreateIdleState()
    {
        idleState = (fsm, gameObj) =>
        {
            HashSet<KeyValuePair<GOAP.ActionKey, object>> worldState = dataProvider.GetWorldState();
            HashSet<KeyValuePair<GOAP.ActionKey, object>> goal = dataProvider.CreateGoalState();

            Queue<GOAP.Action> plan = planner.Plan(gameObject, availableActions, worldState, goal);
            if (plan != null)
            {
                currentActions = plan;
				dataProvider.PlanFound(goal, plan);
				actions = currentActions.ToArray();

                fsm.PopState();
                fsm.PushState(performActionState);

            }
            else
            {
                Debug.Log("<color=orange>Failed Plan:</color>" + ToString(goal));
                dataProvider.PlanFailed(goal);
                fsm.PopState();
                fsm.PushState(idleState);
            }
        };
    }

	private void CreateMoveToState()
	{
		moveToState = (fsm, gameObj) => {
			GOAP.Action action = currentActions.Peek();
			if (action.RequiresInRange() && action.target == null)
			{
				Debug.Log("<color=red>Fatal error:</color> Action requires a target but has none. Planning failed. You did not assign the target in your Action.checkProceduralPrecondition()");
				fsm.PopState();
				fsm.PopState();
				fsm.PushState(idleState);
				return;
			}

			if (dataProvider.MoveAgent(action))
			{
				fsm.PopState();
			}
		};
	}

	private void CreatePerformActionState()
	{

		performActionState = (fsm, gameObj) => {
			// perform the action
			GOAP.Action action = currentActions.Peek();
			if (action.IsDone())
			{
				currentActions.Dequeue();
			}

			if (!HasActionPlan())
			{
				// no actions to perform
				Debug.Log("<color=red>Done actions</color>");
				fsm.PopState();
				fsm.PushState(idleState);
				dataProvider.ActionsFinished(action);
				return;
			}
			else
			{
				action = currentActions.Peek();
				bool inRange = action.RequiresInRange() ? action.inRange : true;

				if (inRange)
				{
					bool success = action.Perform(gameObj);

                    // If action fails, abort plan
                    if (!success)
                    {
						OverridePlan();
                        dataProvider.PlanAborted(action);
                    }
                }
				else
				{
					fsm.PushState(moveToState);
				}
			}
		};
	}

    public void OverridePlan()
    {
        stateMachine.PopState();
        stateMachine.PushState(idleState);
    }

    private void FindDataProvider()
	{
		foreach (Component comp in gameObject.GetComponents(typeof(Component)))
		{
			if (typeof(GOAP.Interface).IsAssignableFrom(comp.GetType()))
			{
				dataProvider = (GOAP.Interface)comp;
				return;
			}
		}
	}

	private void LoadActions()
	{
		GOAP.Action[] actions = gameObject.GetComponents<GOAP.Action>();
		foreach (GOAP.Action a in actions)
		{
			availableActions.Add(a);
		}
	}

	public static string ToString(HashSet<KeyValuePair<GOAP.ActionKey, object>> state)
	{
		String s = "";
		foreach (KeyValuePair<GOAP.ActionKey, object> kvp in state)
		{
			s += kvp.Key + ":" + kvp.Value.ToString();
			s += ", ";
		}
		return s;
	}

	public static string ToString(Queue<GOAP.Action> actions)
	{
		String s = "";
		foreach (GOAP.Action a in actions)
		{
			s += a.GetType().Name;
			s += "-> ";
		}
		s += "GOAL";
		return s;
	}

	public static string ToString(GOAP.Action[] actions)
	{
		String s = "";
		foreach (GOAP.Action a in actions)
		{
			s += a.GetType().Name;
			s += ", ";
		}
		return s;
	}

	public static string ToString(GOAP.Action action)
	{
		String s = "" + action.GetType().Name;
		return s;
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		if (Gizmo.IsPlaying)
		{
			if (currentActions == null || currentActions.Count == 0)
				return;

			GOAP.Action current = currentActions.Peek();
			bool selected = false;

			GameObject target = current.target;
			if (target == null)
				target = gameObject;

			switch (Gizmo.show)
			{
				case Gizmo.Filter.Agent:
					selected = Gizmo.SelectedInHierachy == gameObject;
					break;

				case Gizmo.Filter.Action:
					selected = target.gameObject == Gizmo.SelectedInHierachy;
					break;

				case Gizmo.Filter.All:
					selected = true;
					break;
			}

			if (selected)
			{
				Gizmo.DrawLine(target.transform.position, transform.position, Color.yellow);
				Gizmo.DrawCircle(target.transform.position, 16, current.minExecDist / 1.5f, Color.yellow);

				Gizmo.DrawText(transform.position, current.GetType().Name);
			}
		}
	}
#endif
}
