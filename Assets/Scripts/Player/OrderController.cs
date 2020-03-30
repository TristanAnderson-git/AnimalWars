using UnityEngine;
using UnityEngine.InputSystem;

public class OrderController : MonoBehaviour
{
    public GOAP.Order[] orderOptions = new GOAP.Order[4];
    public float radius;
    public LayerMask unitLayer;

    private bool[] activeOrders;

    private void Awake()
    {
        activeOrders = new bool[4];
    }

    void OnUnknown(InputValue value) => activeOrders[(int)OrderControls.Unknown] = value.isPressed;
    void OnAttack(InputValue value) => activeOrders[(int)OrderControls.Attack] = value.isPressed;
    void OnGather(InputValue value) => activeOrders[(int)OrderControls.Gather] = value.isPressed;
    void OnFollow(InputValue value) => activeOrders[(int)OrderControls.Follow] = value.isPressed;

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
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
    }
#endif
}