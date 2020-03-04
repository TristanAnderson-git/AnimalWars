using GOAP;
using UnityEngine;

public class ActionStayAlive : Action
{
    bool isFinished;

    public override void Reset()
    {
        base.Reset();

        isFinished = false;
    }

    public ActionStayAlive()
    {
        AddEffect(ActionKey.StayAlive, true);
    }

    public override bool CheckPreconditions(GameObject agent)
    {
        return true;
    }

    public override bool IsDone()
    {
        return isFinished;
    }

    public override bool Perform(GameObject agent)
    {
        print("I am currently alive");
        isFinished = true;
        return true;
    }

    public override bool RequiresInRange()
    {
        return false;
    }
}
