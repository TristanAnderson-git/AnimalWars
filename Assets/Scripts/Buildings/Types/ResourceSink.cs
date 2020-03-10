using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Resource
{
    public ResourceType type;
    public int amount;
}

public class ResourceSink : Building
{
    public ResourceType type;

    public int maximumWorkers;
    public int productionAmount;

    public int maximumStorage;
    public int currentStorage;

    protected override void Init()
    {
    }

    public override void Die()
    {
        if (existsInEnvirenment)
        {
            owner = -1;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public override void Perform()
    {
        currentStorage = Mathf.Clamp(currentStorage + productionAmount, 0, maximumStorage);
    }

    public int WithdrawResource(Unit unit)
    {
        int harvestAmount = Mathf.Min(unit.stats.harvestPerSecond, currentStorage);
        currentStorage -= harvestAmount;
        return harvestAmount;
    }
}
