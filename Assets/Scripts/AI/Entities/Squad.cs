using GOAP;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[RequireComponent(typeof(GOAPAgent))]
[RequireComponent(typeof(NavMeshAgent))]
public class Squad : MonoBehaviour, GOAP.Interface
{
    public int maxSquadSize;
    public List<Unit> units;
    public LayerMask unitMask;
    public float unitSearchRadius;
    public float unitPositionRadius;
    public bool uberCharged; // True if squad currently holds more units than the maximum squad size;
    public int squadSizeAffordance;

    public int Size { get { return units.Count; } }

    private NavMeshAgent navAgent;

    public int currentCommand;
    private int previousCommand;
    public ActionKey secondayGoalKey;

    private HashSet<KeyValuePair<ActionKey, object>> goal;
    private KeyValuePair<ActionKey, object> secondaryGoal;

    void Start()
    {
        goal = new HashSet<KeyValuePair<ActionKey, object>>();
        units = new List<Unit>();

        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Size < maxSquadSize)
            FindUnits();
    }

    void FindUnits()
    {
        Collider[] unitsFound = Physics.OverlapSphere(transform.position, unitSearchRadius, unitMask);
        if (unitsFound.Length > 0)
        {
            for (int i = 0; i < unitsFound.Length; i++)
            {
                if (Size >= maxSquadSize)
                    break;

                Unit unit = unitsFound[i].GetComponent<Unit>();
                
                if (unit.hasSquad && unit.squad != this) 
                {
                    Squad foreignSquad = unit.squad;

                    if (foreignSquad.uberCharged)
                        foreignSquad.TransferUnit(unit, this);
                    
                    else if (Size + foreignSquad.Size <= squadSizeAffordance + maxSquadSize) 
                    {
                        for (int u = 0; u < foreignSquad.Size; u++)
                            foreignSquad.TransferUnit(foreignSquad.units[u], this);

                        if (Size > maxSquadSize)
                            uberCharged = true;
                    }
                }

                AddUnit(unit);
            }
        }
    }

    public void AddUnit(Unit unit)
    {
        unit.SetupSquad(this);
        units.Add(unit);

        uberCharged = Size > maxSquadSize;
    }
    public void TransferUnit(Unit unitToTransfer, Squad recipientSquad)
    {
        units.Remove(unitToTransfer);
        recipientSquad.AddUnit(unitToTransfer);
    
        uberCharged = Size > maxSquadSize;

        if (Size == 0)
            Destroy(gameObject);
    }
    
    public void UpdateUnitPosition()
    {
        float distanceRatio = 1;

        NavMeshHit hit;
        if (NavMesh.FindClosestEdge(transform.position, out hit, NavMesh.AllAreas))
        {
            if (hit.distance > unitPositionRadius)
            {
                distanceRatio = hit.distance / unitPositionRadius;
            }
        }

        for (int i = 0; i < Size; i++)
        {
            if (units[i].moveRoutine != null)
                StopCoroutine(units[i].moveRoutine);

            Vector3 destination = units[i].relativePositive * distanceRatio;
            units[i].moveRoutine = StartCoroutine(units[i].Move(destination));
        }
    }

    public void GiveCommand(int command)
    {
        currentCommand = command;
    }
    public void GiveSecondaryGoal(ActionKey goal)
    {
        secondaryGoal = new KeyValuePair<ActionKey, object>(goal, true);
    }

    HashSet<KeyValuePair<ActionKey, object>> worldData = new HashSet<KeyValuePair<ActionKey, object>>
        {
            new KeyValuePair<ActionKey, object>(ActionKey.StayAlive, false),
            new KeyValuePair<ActionKey, object>(ActionKey.KillEnemy, false),
            new KeyValuePair<ActionKey, object>(ActionKey.DestroyBase, false),
            new KeyValuePair<ActionKey, object>(ActionKey.DefendBase, false),
            new KeyValuePair<ActionKey, object>(ActionKey.HarvestResource, false),
            new KeyValuePair<ActionKey, object>(ActionKey.GatherResource, false)
        };
    public HashSet<KeyValuePair<ActionKey, object>> GetWorldState()
    {
        return worldData;
    }

    public HashSet<KeyValuePair<ActionKey, object>> CreateGoalState()
    {
        /*
        if (previousCommand == currentCommand)
            return goal;

        goal = new HashSet<KeyValuePair<ActionKey, object>>
        {
            // Default goal, all squads should attempt to kill an enemy squad before proceeding to other goals
            new KeyValuePair<ActionKey, object>(ActionKey.KillEnemy, true),
            new KeyValuePair<ActionKey, object>(ActionKey.StayAlive, true)
        };

        switch (currentCommand)
        {
            case 0: // Attack;
                goal.Add(new KeyValuePair<ActionKey, object>(ActionKey.DestroyBase, true));
                return goal;
            case 1: // Defend;
                goal.Add(new KeyValuePair<ActionKey, object>(ActionKey.DefendBase, true));
                return goal;
            case 2: // Search;
                goal.Add(new KeyValuePair<ActionKey, object>(ActionKey.GatherResource, true));
                return goal;
            default: // No current command
                goal.Add(secondaryGoal);
                return goal;
        }
        */

        goal = new HashSet<KeyValuePair<ActionKey, object>>
        {
            new KeyValuePair<ActionKey, object>(ActionKey.GatherResource, true)
        };

        return goal;
    }

    public void PlanAborted(Action aborter)
    {
    }

    public void PlanFailed(HashSet<KeyValuePair<ActionKey, object>> failedGoal)
    {
    }

    public void PlanFound(HashSet<KeyValuePair<ActionKey, object>> goal, Queue<Action> actions)
    {
    }

    public void ActionsFinished()
    {
    }

    public bool MoveAgent(Action nextAction)
    {
        if (nextAction.target != null)
        {
            if (!navAgent.hasPath)
            {
                navAgent.SetDestination(nextAction.target.transform.position);
                navAgent.stoppingDistance = nextAction.minExecDist;
                navAgent.isStopped = false;
                return false;
            }
            else if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                navAgent.isStopped = true;
                navAgent.ResetPath();
                nextAction.inRange = true;
                return true;
            }
        }
        return false;
    }
}
