using GOAP;
using UnityEngine;

public class ActionHarvestFood : Action
{
    public int maxHarvest;
    public int foodHarvested;
    
    public override void Reset()
    {
        base.Reset();

        foodHarvested = 0;
    }

    ActionHarvestFood()
    {
        AddEffect(ActionKey.HarvestResource, true);
    }

    public override bool CheckPreconditions(GameObject agent)
    {
        return target != null;
    }

    public override bool IsDone()
    {
        if (foodHarvested >= maxHarvest)
        {
            return true;
        }
        return false;
    }

    public override bool Perform(GameObject agent)
    {
        if (foodHarvested < maxHarvest)
        {
            foodHarvested++;
            return true;
        }
        return false;
    }

    public override bool RequiresInRange()
    {
        return true;
    }
}
