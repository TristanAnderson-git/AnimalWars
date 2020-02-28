using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public LayerMask ground;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (moveDir != Vector2.zero)
            Move(moveDir);
    }

    private void Move(Vector2 direction)
    {
        Vector3 origin = new Vector3(transform.position.x + direction.x, 25f, transform.position.z + direction.y);
        Ray ray = new Ray(origin, Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f, ground))
        {
            navAgent.SetDestination(hit.point);
        }
    }
}
