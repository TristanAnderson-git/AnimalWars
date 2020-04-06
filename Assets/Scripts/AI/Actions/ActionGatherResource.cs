using GOAP;
using UnityEngine;
using System.Collections;

public class ActionGatherResource : Action
{
    Unit unit;
    Storage storage;

    public override void Reset()
    {
        base.Reset();

        unit = null;
        storage = null;
    }

    public ActionGatherResource()
    {
        AddPrecondition(ActionKey.HarvestResource, true);
        AddEffect(ActionKey.HarvestResource, false);
        AddEffect(ActionKey.GatherResource, true);
    }

    public override bool CheckPreconditions(GameObject agent)
    {
        unit = GetComponent<Unit>();
        Building[] buildings = GameController.players[unit.owner].ownedBuildings.ToArray();

        for (int i = 0; i < buildings.Length; i++)
        {
            storage = buildings[i].GetComponent<Storage>();
            if (storage != null)
            {
                target = storage.gameObject;
                break;
            }
        }

        return target != null && unit != null && storage != null;
    }

    public override bool IsDone()
    {
        return unit.storage.amountHarvested == 0;
    }

    public override bool Perform(GameObject agent)
    {
        if (unit.storage.amountHarvested > 0)
        {
            if (depositResource == null)
                depositResource = StartCoroutine(DepositResource());
            return true;
        }

        return false;
    }

    private Coroutine depositResource = null;
    private IEnumerator DepositResource()
    {
        yield return new WaitForSeconds(1.0f);

        storage.DepositRecource(unit);

        depositResource = null;
    }


    public override bool RequiresInRange()
    {
        return true;
    }
}
