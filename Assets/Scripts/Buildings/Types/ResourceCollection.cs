using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Resource
{
    public ResourceType type;
    public int amount;
}

public class ResourceCollection : Building
{
    public ResourceType type;

    public int maximumWorkers;
    public int productionAmount;

    public int maximumStorage;
    public int currentStorage;

    public Unit workers;

    private bool preExists = true;

    public override void Die()
    {
        if (preExists)
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
}
