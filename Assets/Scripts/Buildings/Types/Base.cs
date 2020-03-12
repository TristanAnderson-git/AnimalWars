using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Building
{
    private Hut hut;
    private Storage storage;
    private ResourceSink sink;

    public override void Init()
    {
        hut = GetComponent<Hut>();
        storage = GetComponent<Storage>();
        sink = GetComponent<ResourceSink>();

        hut.health = storage.health = sink.health = health;
        hut.owner = storage.owner = sink.owner = owner;
        hut.refreshPerformTime = storage.refreshPerformTime = sink.refreshPerformTime = refreshPerformTime;

        hut.Init();

        // Spawn in starting units
        for (int i = 0; i < 5; i++)
            hut.Perform();

        StartTask();
    }

    public override void Die()
    {
        if (GameController.players[owner] != null)
        {
            GameController.players[owner].RemoveBuilding(this);
            GameController.players[owner] = null;
        }

        Destroy(gameObject);
    }

    public override void Perform()
    {
        if (GameController.players[owner].ownedUnitCount < 5)
            hut.Perform();

        sink.Perform();
        storage.DepositRecource(sink);
        storage.Perform();
    }
}
