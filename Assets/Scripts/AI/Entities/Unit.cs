using GOAP;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[System.Serializable]
public struct UnitStats
{
    public float speed;
    public float attack;
    public int harvestPerSecond;
}

[System.Serializable]
public struct UnitStorage
{
    public ResourceType type;
    public int maxHarvest;
    public int amountHarvested;
}

[RequireComponent(typeof(GOAPAgent))]
[RequireComponent(typeof(NavMeshAgent))]
public class Unit : Entity, GOAP.Interface
{
    private GOAPAgent goapAgent;
    private NavMeshAgent navAgent;

    public byte CurrentOrderPriority { get { return (currentOrder != null) ? currentOrder.priority : (byte)0; } } 
    private Order currentOrder = null;
    public ActionKey secondayGoalKey;

    private HashSet<KeyValuePair<ActionKey, object>> goal;
    
    public UnitStats stats;
    public UnitStorage storage;

    void Start()
    {
        goal = new HashSet<KeyValuePair<ActionKey, object>>();

        goapAgent = GetComponent<GOAPAgent>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckHealth();
    }

    public void Spawn(int health, UnitStats stats, UnitStorage storage, int owner)
    {
        this.health = health;
        this.stats = stats;
        this.storage = storage;
        this.owner = owner;
    }

    // GOAP AGENT FUNCTIONALITY
    public void GiveOrder(Order order)
    {
        currentOrder = order;
        goapAgent.OverridePlan();
    }

    public void GiveSecondaryGoal(ActionKey goal)
    {
        secondayGoalKey = goal;
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
        goal = new HashSet<KeyValuePair<ActionKey, object>>
        {
            new KeyValuePair<ActionKey, object>((currentOrder != null) ? currentOrder.goal : secondayGoalKey, true)
        };

        return goal;
    }

    public void PlanAborted(Action aborter)
    {
        ResetActiveGoal();
    }

    public void PlanFailed(HashSet<KeyValuePair<ActionKey, object>> failedGoal)
    {
    }

    public void PlanFound(HashSet<KeyValuePair<ActionKey, object>> goal, Queue<Action> actions)
    {
    }

    public void ActionsFinished()
    {
        ResetActiveGoal();
    }

    public void ResetActiveGoal()
    {
        if (currentOrder != null)
            currentOrder = null;
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

    // ENTITY FUNCTIONALITY
    public override void Die()
    {
        GameController.players[owner].ownedUnitCount--;
        Destroy(gameObject);
    }
}
