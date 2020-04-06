using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    static waveSpawner instance;
    public static uint numberOfEnemies;

    [Header("unity stuff")]
    public Image baseHealth;

    // Start is called before the first frame update
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI enemyCountText;

    private int waveNumber = 0;
    private float timeRemaining = 0;
    public static int lives = 3; 

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (timeRemaining <= 0)
            StartCoroutine(spawnWave());
        else
            timeRemaining -= Time.deltaTime;

        waveCountDownText.SetText((Mathf.FloorToInt(timeRemaining) + 1).ToString());

        baseHealth.fillAmount = Mathf.Clamp((float)lives / 3f, 0, 1);
    }

    IEnumerator spawnWave()
    {
        timeRemaining = timeBetweenWaves;

        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        OnEnemySpawned();
    }

    public static void OnEnemySpawned()
    {
        numberOfEnemies++;
        instance.UpdateEnemyCount();
    }
    public static void OnEnemyKilled()
    {
        numberOfEnemies--;
        instance.UpdateEnemyCount();
    }

    public void UpdateEnemyCount()
    {
        instance.enemyCountText.SetText(numberOfEnemies.ToString());
    }
}
