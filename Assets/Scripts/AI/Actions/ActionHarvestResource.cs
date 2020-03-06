using GOAP;
using System.Collections;
using UnityEngine;

public class ActionHarvestResource : Action
{
    private Unit unit = null;

    public override void Reset()
    {
        base.Reset();

        if (unit != null)
        {
            unit.storage.amountHarvested = 0;
        }
    }

    ActionHarvestResource()
    {
        AddEffect(ActionKey.HarvestResource, true);
    }

    public override bool CheckPreconditions(GameObject agent)
    {
        unit = GetComponent<Unit>();

        return target != null;
    }

    public override bool IsDone()
    {
        if (unit.storage.amountHarvested >= unit.storage.maxHarvest)
        {
            return true;
        }
        return false;
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
        unit.storage.amountHarvested = Mathf.Clamp(unit.storage.amountHarvested + unit.stats.harvestPerSecond, 0, unit.storage.maxHarvest);
        collectResource = null;
    }

    public override bool RequiresInRange()
    {
        return true;
    }
}
