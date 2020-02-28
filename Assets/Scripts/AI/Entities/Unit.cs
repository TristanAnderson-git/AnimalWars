using UnityEngine;
using System.Collections;

public class Unit : Entity
{
    // Replace this float
    float speed = 1;

    public bool hasSquad;
    public Squad squad;

    [HideInInspector]
    public Vector3 relativePositive;

    public void SetupSquad(Squad squad)
    {
        relativePositive = Vector3.positiveInfinity;

        while(!IsInCircle(relativePositive, squad.unitPositionRadius))
        {
            relativePositive.x = Random.Range(-squad.unitPositionRadius, squad.unitPositionRadius);
            relativePositive.z = Random.Range(-squad.unitPositionRadius, squad.unitPositionRadius);
        }

        this.squad = squad;
        transform.SetParent(squad.transform);

        if (moveRoutine != null)
            StopCoroutine(moveRoutine);
        moveRoutine = StartCoroutine(Move(relativePositive));
    }

    public Coroutine moveRoutine = null;
    public IEnumerator Move(Vector3 positionToMove)
    {
        while (transform.localPosition != positionToMove)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, positionToMove, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }

    bool IsInCircle(Vector3 point, float radius)
    {
        return ((point.x * point.x) + (point.z * point.z)) <= (radius * radius);
    }
}
