using UnityEngine;
using UnityEngine.InputSystem;

public class OrderController : MonoBehaviour
{
    public GOAP.Order[] orderOptions = new GOAP.Order[4];
    public float radius;
    public LayerMask unitLayer;

    public SpriteRenderer sprite;

    private bool[] activeOrders;

    private void Awake()
    {
        activeOrders = new bool[4];
    }

    void OnUnknown(InputValue value) { activeOrders[0] = value.isPressed; }
    void OnAttack(InputValue value) { activeOrders[1] = value.isPressed; }
    void OnGather(InputValue value) { activeOrders[2] = value.isPressed; }
    void OnFollow(InputValue value) { activeOrders[3] = value.isPressed; }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (activeOrders[i])
            {
                GiveOrder(orderOptions[i]);
                return;
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
}