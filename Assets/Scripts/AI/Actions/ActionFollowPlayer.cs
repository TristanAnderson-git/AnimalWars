using GOAP;
using UnityEngine;
using UnityEngine.AI;

public class ActionFollowPlayer : Action
{
    NavMeshAgent navAgent;
    Unit unit;

    public override void Reset()
	{
        base.Reset();

        if (navAgent != null)
            navAgent.ResetPath();
    }

	public ActionFollowPlayer()
	{
        AddEffect(ActionKey.FollowPlayer, true);
	}

	public override bool CheckPreconditions(GameObject agent)
	{
        if (unit == null)
            unit = GetComponent<Unit>();

        if (navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();

        if(GameController.players.Count >= 0 && target == null)
            target = GameController.players[unit.owner].gameObject;

        return target != null && navAgent != null;
    }

    public override bool IsDone()
	{
        return minExecDist > Vector3.Distance(transform.position, target.transform.position);
    }

	public override bool Perform(GameObject agent)
	{
        if (minExecDist < Vector3.Distance(transform.position, target.transform.position))
            navAgent.SetDestination(target.transform.position);


        return true;
    }

	public override bool RequiresInRange()
	{
        return false;
	}

}
