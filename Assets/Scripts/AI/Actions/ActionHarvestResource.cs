using GOAP;
using System.Collections;
using UnityEngine;

public class ActionHarvestResource : Action
{
    public LayerMask resourceSink;

    private Unit unit = null;
    private ResourceSink sink = null;

    public override void Reset()
    {
        base.Reset();
    }

    ActionHarvestResource()
    {
        AddEffect(ActionKey.HarvestResource, true);
    }

    public override bool CheckPreconditions(GameObject agent)
    {
        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 25.0f, resourceSink);
            target = Nearest(colliders);
        }

        unit = GetComponent<Unit>();
        if (target != null)
            sink = target.GetComponent<ResourceSink>();
        
        return target != null && unit != null && sink != null;
    }

    public override bool IsDone()
    {
        return unit.storage.amountHarvested >= unit.storage.maxHarvest;
    }

    public override bool Perform(GameObject agent)
    {
        if (unit.storage.amountHarvested < unit.storage.maxHarvest)
        {
            if (collectResource == null)
                collectResource = StartCoroutine(CollectResource());
            return true;
        }

        return false;
    }

    private Coroutine collectResource = null;
    private IEnumerator CollectResource()
    {
        yield return new WaitForSeconds(1.0f);

        int harvestAmount = sink.WithdrawResource(unit);
        unit.storage.amountHarvested = Mathf.Clamp(unit.storage.amountHarvested + harvestAmount, 0, unit.storage.maxHarvest);
        
        collectResource = null;
    }

    public override bool RequiresInRange()
    {
        return true;
    }

    GameObject Nearest(Collider[] points)
    {
        int nearest = -1;
        float nearestDistance = Mathf.Infinity;

        for (int i = 0; i < points.Length; i++)
        {
            float distance = Mathf.Abs(Vector3.Distance(transform.position, points[i].transform.position));
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = i;
            }
        }
        
        return (nearest >= 0) ? points[nearest].gameObject : null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 25.0f);
    }
#endif
}
