using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public float starthealth = 100;
    private float health;

    private Transform target;
    private int wavepointIndex = 0;

    [Header("unity stuff")]
    public Image healthbar;

    private void Start()
    {
        target = waitpoints.points[0];
        health = starthealth;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaitPoint();
        }

        void GetNextWaitPoint()
        {
            if (wavepointIndex >= waitpoints.points.Length - 1)
            {
                waveSpawner.OnEnemyKilled();
                Destroy(gameObject);
                return;
            }
            wavepointIndex++;
            target = waitpoints.points[wavepointIndex];
        }
    }
    
    public void damage (float amount)
    {
        health -= amount;
        healthbar.fillAmount = health / starthealth;
    }

    void OnMouseDown()
    {
        damage(25);

        if (health <= 0)
        {
            // Update with RTS base resource storage
            //recources.watervalue += 3;
            //recources.woodvalue += 3;
            //recources.rocksvalue += 3;
            //recources.foodvalue += 3;

            waveSpawner.OnEnemyKilled();

            Destroy(gameObject);
        }
    }
}
