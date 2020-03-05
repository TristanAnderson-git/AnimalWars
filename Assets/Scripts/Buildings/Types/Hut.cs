using UnityEngine;

public class Hut : Building
{
    public UnitData unitData;
    public GameObject unitPrefab;
    public float spawnDistance;

    private Vector3 spawnPoint = Vector3.zero;

    void Start()
    {
        spawnPoint = spawnDistance * transform.forward;
    }

    public override void Perform()
    {
        Unit unit = Instantiate(unitPrefab, spawnPoint, transform.rotation).GetComponent<Unit>();
        unit.Spawn(unitData.health, unitData.stats);
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
        Gizmo.DrawCircle(spawnPoint, 8, 0.1f, Color.green);
    }
#endif
}