using UnityEngine;

public class Storage : Building
{
    public int[] resources = new int[4];

    public override void Init()
    {
    }

    public override void Die()
    {

    }

    public override void Perform()
    {

    }

    public void DepositRecource(Unit unit)
    {
        int amount = Mathf.Min(unit.stats.harvestPerSecond, unit.storage.maxHarvest);

        unit.storage.amountHarvested -= amount;
        resources[(int)unit.storage.type] += amount;
    }

    public void DepositRecource(ResourceSink sink)
    {
        int amount = Mathf.Min(sink.productionAmount, sink.maximumStorage);

        sink.currentStorage -= amount;

        for (int i = 0; i < 4; i++)
            resources[i] += amount;
    }

    public void DepositRecource(int[] amount)
    {
        for (int i = 0; i < 4; i++)
            resources[i] += amount[i];
    }
}
