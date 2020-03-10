using GOAP;
using UnityEngine;
using System.Collections;

public class ActionAttackTarget : Action
{
    Entity entity = null;

    public override void Reset()
	{
        base.Reset();
    }

	public ActionAttackTarget()
	{
        AddEffect(ActionKey.KillEnemy, true);
        AddEffect(ActionKey.DestroyBase, true);
    }

	public override bool CheckPreconditions(GameObject agent)
	{
        if (target != null || entity == null)
            entity = target.GetComponent<Entity>();

        return target != null || entity != null;
    }

	public override bool IsDone()
	{
        return entity.health <= 0;
	}

	public override bool Perform(GameObject agent)
	{
        if (recover == null)
            recover = StartCoroutine(RecoverFromAttack(1.5f));
        return true;
	}

    Coroutine recover = null;
    IEnumerator RecoverFromAttack(float waitTime)
    {
        entity.health -= 0; // Some calculated damage value
        print("ATTACK!");

        yield return new WaitForSeconds(waitTime);
        recover = null;
    }

    public override bool RequiresInRange()
	{
		return true;
	}

}
