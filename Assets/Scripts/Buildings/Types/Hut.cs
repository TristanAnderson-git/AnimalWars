using UnityEngine;

public class Hut : Building
{
    public UnitData unitData;
    public GameObject unitPrefab;
    public float spawnDistance;

    private Vector3 spawnPoint = Vector3.zero;

    public override void Init()
    {
        spawnPoint = spawnDistance * transform.forward + transform.position;
    }

    public override void Perform()
    {
        Unit unit = Instantiate(unitPrefab, spawnPoint, transform.rotation).GetComponent<Unit>();
        GameController.players[owner].ownedUnitCount++;
        unit.Spawn(unitData.health, unitData.stats, unitData.storage, owner);
    }

    public override void Die()
    {
        if (currentState != null)
            StopCoroutine(currentState);

        gameObject.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 point = spawnDistance * transform.forward + transform.position;
        Gizmo.DrawCircle(point, 8, 0.5f, Color.green);
    }
#endif
}