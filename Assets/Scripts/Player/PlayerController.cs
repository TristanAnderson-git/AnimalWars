using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerSelectOption selectOption;

    public int ownedUnitCount;
    public List<Building> ownedBuildings;
    public uint playerID;

    void OnConfirm() => selectOption.SetReady(true);
    void OnCancel() => selectOption.SetReady(false);

    public void GetBase()
    {
        Base myBase = GameObject.Find("Base").GetComponent<Base>();
        ownedBuildings.Add(myBase);
    }

    public void RemoveBuilding(Building building)
    {
        ownedBuildings.Remove(building);
    }
}
