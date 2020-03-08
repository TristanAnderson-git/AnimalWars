using UnityEngine;
using UnityEngine.InputSystem;

public class OrderController : MonoBehaviour
{
    private PlayerControls controls;

    public GOAP.Order[] orderOptions = new GOAP.Order[4];
    public float radius;
    public LayerMask unitLayer;

    private bool[] activeOrders;

    private void Awake()
    {
        activeOrders = new bool[4];
    }

    void OnOrder_0(InputValue value) => activeOrders[0] = value.isPressed;
    void OnOrder_1(InputValue value) => activeOrders[1] = value.isPressed;
    void OnOrder_2(InputValue value) => activeOrders[2] = value.isPressed;
    void OnOrder_3(InputValue value) => activeOrders[3] = value.isPressed;

    private void OnEnable()
    {
        if (controls != null)
            controls.Orders.Enable();
    }

    private void OnDisable()
    {
        if (controls != null)
            controls.Orders.Disable();
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (activeOrders[i])
            {
                GiveOrder(orderOptions[i]);
                break;
            }
        }
    }

    private void GiveOrder(GOAP.Order order)
    {
        Collider[] units = Physics.OverlapSphere(transform.position, radius, unitLayer);
        
        for (int i = 0; i < units.Length; i++)
        {
            Unit unit = units[i].GetComponent<Unit>();

            if (unit != null)
            {
                if (unit.CurrentOrderPriority <= order.priority || order.priority == 0)
                    unit.GiveOrder(order);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (activeOrders == null)
            return;

        for (int i = 0; i < activeOrders.Length; i++)
        {
            if (activeOrders[i])
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
    }
#endif
}