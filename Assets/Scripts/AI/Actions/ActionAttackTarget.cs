using GOAP;
using UnityEngine;
using System.Collections;

public class ActionAttackTarget : Action
{
    bool attacked = false;
    Entity entity = null;

    public override void Reset()
	{
        base.Reset();

        attacked = false;
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
        entity.health -= 0; // Some calculated damage value
                            // Add some recovery time to prevent attacking every frame

        if (recover == null)
            recover = StartCoroutine(RecoverFromAttack(1.5f));
        return true;
	}

    Coroutine recover = null;
    IEnumerator RecoverFromAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        attacked = true;
        print("ATTACK!");
        recover = null;
    }

    public override bool RequiresInRange()
	{
		return true;
	}

}
