using UnityEngine;
using GOAP;

public class ActionGatherResource : Action
{
    bool isFinished;

    public override void Reset()
    {
        base.Reset();

        isFinished = false;
    }

    public ActionGatherResource()
    {
        AddPrecondition(ActionKey.HarvestResource, true);
        AddEffect(ActionKey.HarvestResource, false);
        AddEffect(ActionKey.GatherResource, true);
    }

    public override bool CheckPreconditions(GameObject agent)
    {
        return target != null;
    }

    public override bool IsDone()
    {
        return isFinished;
    }

    public override bool Perform(GameObject agent)
    {
        isFinished = true;
        return true;
    }

    public override bool RequiresInRange()
    {
        return true;
    }
}
