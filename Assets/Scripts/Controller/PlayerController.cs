using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    public LayerMask ground;
    public PlayerSelectOption selectOption;
    
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
}
