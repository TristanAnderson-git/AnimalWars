using UnityEngine;
using UnityEngine.InputSystem;

public class OrderController : MonoBehaviour
{
    [System.Serializable]
    public struct OrderOption
    {
        public string button;
        public GOAP.Order order;
    }

    private PlayerControls controls;

    public OrderOption[] orderOptions = new OrderOption[4];
    public float radius;
    public LayerMask unitLayer;

    private bool[] activeOrders;

    private void Awake()
    {
        activeOrders = new bool[4];

        controls = new PlayerControls();

        controls.Gameplay.Order_0.performed += ctx => activeOrders[0] = true;
        controls.Gameplay.Order_1.performed += ctx => activeOrders[1] = true;
        controls.Gameplay.Order_2.performed += ctx => activeOrders[2] = true;
        controls.Gameplay.Order_3.performed += ctx => activeOrders[3] = true;

        controls.Gameplay.Order_0.canceled += ctx => activeOrders[0] = false;
        controls.Gameplay.Order_1.canceled += ctx => activeOrders[1] = false;
        controls.Gameplay.Order_2.canceled += ctx => activeOrders[2] = false;
        controls.Gameplay.Order_3.canceled += ctx => activeOrders[3] = false;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (activeOrders[i])
            {
                GiveOrder(orderOptions[i].order);
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
                if (unit.CurrentOrderPriority <= order.priority)
                    unit.GiveOrder(order);
            }
        }
    }
}