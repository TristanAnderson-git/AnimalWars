using GOAP;
using UnityEngine;

public class ActionNewAction : Action
{
	public override void Reset()
	{
	}

	public ActionNewAction()
	{
	}

	public override bool CheckPreconditions(GameObject agent)
	{
		return true;
	}

	public override bool IsDone()
	{
		return true;
	}

	public override bool Perform(GameObject agent)
	{
		return true;
	}

	public override bool RequiresInRange()
	{
		return true;
	}

}
