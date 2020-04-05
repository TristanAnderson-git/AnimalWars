using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public float starthealth = 100;
    [HideInInspector] public float health;

    public bool isBeingAttacked = false;

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
        if (!isBeingAttacked)
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
                    Destroy(GameController.players[0].gameObject);
                    Destroy(GameController.instance.gameObject);

                    waveSpawner.OnEnemyKilled();
                    Destroy(gameObject);

                    SceneManager.LoadScene(0);
                    return;
                }
                wavepointIndex++;
                target = waitpoints.points[wavepointIndex];
            }
        }
    }
    
    public void damage (float amount)
    {
        health -= amount;
        healthbar.fillAmount = health / starthealth;
    }

    public void ReceiveDamage(float amount)
    {
        damage(amount);

        if (health <= 0)
        {
            // Update with RTS base resource storage
            Base.storage.DepositRecource(new int[4]{ 3, 3, 3, 3 });

            waveSpawner.OnEnemyKilled();

            Destroy(gameObject);
        }
    }

    public void UpdateUnitHealth()
    {
        health -= 25;
        healthbar.fillAmount = health / starthealth;
    }
}
