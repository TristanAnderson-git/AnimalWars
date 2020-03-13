using GOAP;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionAttackTarget : Action
{
    Entity entity = null;
    public LayerMask unit;

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
        Unit u = GetComponent<Unit>();

        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 25.0f, unit);
            List<Collider> enemies= new List<Collider>();

            for (int i = 0; i < colliders.Length; i++)
            {
                Entity e = colliders[i].GetComponent<Entity>();

                if (e != null && e.owner != u.owner)
                    enemies.Add(colliders[i]);
            }

            if (enemies.Count > 0)
                target = Nearest(enemies.ToArray());
        }

        if (target != null && entity == null)
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
        yield return new WaitForSeconds(waitTime);
        recover = null;
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
}
