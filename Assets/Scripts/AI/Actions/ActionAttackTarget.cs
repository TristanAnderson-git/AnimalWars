using GOAP;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionAttackTarget : Action
{
    public LayerMask enemyLayer;
    private enemy enemy = null;
    private float damageValue = 0;

    public override void Reset()
	{
        base.Reset();
    }

	public ActionAttackTarget()
	{
        AddEffect(ActionKey.KillEnemy, true);
    }

	public override bool CheckPreconditions(GameObject agent)
	{
        Unit u = GetComponent<Unit>();
        damageValue = u.stats.attack;

        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 25.0f, enemyLayer);
            List<Collider> enemies= new List<Collider>();

            for (int i = 0; i < colliders.Length; i++)
            {
                enemy e = colliders[i].GetComponent<enemy>();

                if (e != null)
                    enemies.Add(colliders[i]);
            }

            if (enemies.Count > 0)
                target = Nearest(enemies.ToArray());
        }

        if (target != null && enemy == null)
        {
            enemy = target.GetComponent<enemy>();
        }

        return target != null || enemy != null;
    }

	public override bool IsDone()
	{
        return enemy.health <= 0;
	}

	public override bool Perform(GameObject agent)
	{
        enemy.isBeingAttacked = true;
        
        if (recover == null)
            recover = StartCoroutine(RecoverFromAttack(1.5f));
        return true;
	}

    Coroutine recover = null;
    IEnumerator RecoverFromAttack(float waitTime)
    {
        enemy.ReceiveDamage(damageValue);
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
