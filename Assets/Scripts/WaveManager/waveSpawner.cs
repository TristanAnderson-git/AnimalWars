using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    static waveSpawner instance;
    public static uint numberOfEnemies;

    public float startUnithealth = 100;
    [HideInInspector] public float Unithealth;
    [Header("unity stuff")]
    public Image Unithealthbar;

    // Start is called before the first frame update
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI enemyCountText;

    private int waveNumber = 0;
    private float timeRemaining = 0;

   

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        Unithealth = startUnithealth;
    }

    void Update()
    {
        if (timeRemaining <= 0)
            StartCoroutine(spawnWave());
        else
            timeRemaining -= Time.deltaTime;

        waveCountDownText.SetText((Mathf.FloorToInt(timeRemaining) + 1).ToString());
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
        instance.enemyCountText.SetText(" " + numberOfEnemies);
    }

    public void UpdateUnitHealth()
    {

    }
}
