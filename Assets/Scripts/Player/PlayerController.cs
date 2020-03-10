using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    public PlayerSelectOption selectOption;

    public int ownedUnitCount;
    public List<Building> ownedBuildings;
    public uint playerID;

    void OnMove(InputValue value) => moveDir = value.Get<Vector2>();

    void OnConfirm() => selectOption.SetReady(true);
    void OnCancel() => selectOption.SetReady(false);

    private void Update()
    {
        if (moveDir != Vector2.zero)
            Move(moveDir);
    }

    private void Move(Vector2 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(direction.x, 0, direction.y) + transform.position, Time.deltaTime * 7.5f);
    }

    public void RemoveBuilding(Building building)
    {
        ownedBuildings.Remove(building);
    }
}
