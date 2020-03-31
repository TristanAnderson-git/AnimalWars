using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActionAsset inputAsset;
    public PlayerSelectOption selectOption;
    public bool canMove = true;

    public int ownedUnitCount;
    public List<Building> ownedBuildings;
    public uint playerID;

    void OnConfirm() => selectOption.SetReady(true);
    void OnCancel() => selectOption.SetReady(false);

    private void Start()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        if (inputAsset != null)
            inputAsset.Enable();
    }

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
