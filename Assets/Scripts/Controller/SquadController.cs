using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadController : MonoBehaviour
{
    public int maxUnitsPerPlayer;
    public int numberOfPlayers;

    public GameObject unitPrefab;
    public GameObject unitBase;
    public GameObject farmland;
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnSquads());
    }

    IEnumerator SpawnSquads()
    {
        for (int n = 0; n < numberOfPlayers; n++)
        {
            for (int i = 0; i < maxUnitsPerPlayer; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40));
                GameObject go = Instantiate(unitPrefab, randomPos, Quaternion.identity);

                //Set Action Targets
                go.GetComponent<ActionGatherResource>().target = unitBase;
                //go.GetComponent<ActionHarvestResource>().target = farmland;
                go.GetComponent<ActionAttackTarget>().target = enemy;

                yield return null;
            }
        }
    }
}
