using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static List<PlayerController> players;

    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    public PlayerSelectMenu playerSelectMenu;

    public static PlayerInputManager GetPlayerInputManager()
    {
        return instance.playerInputManager;
    }

    private PlayerInputManager playerInputManager;
    
    void Awake()
    {
        // create singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    void Update()
    {
        if (players.Count <= 1)
            EndMatch();
    }

    public void StartMatch()
    {
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += SetUp;
    }

    public static void EndMatch()
    {

    }

    private void SetUp(Scene scene, LoadSceneMode mode)
    {
        SetupPlayers();
        SetUpBuilding();

        // Clean up delegate
        SceneManager.sceneLoaded -= SetUp;
    }

    private void SetupPlayers()
    {
        for (int i = 0; i < players.Count; i++)
        {
            GameObject camera = Instantiate(cameraPrefab);
            camera.GetComponent<CameraController>().SetUp(i, players.Count, players[i].transform);
            InspectorName(camera, "Player" + players.Count + " Camera");
        }
    }

    private void SetUpBuilding()
    {
        for (int i = 0; i < players.Count; i++)
            players[i].GetBase();
    }

    public void OnPlayerJoined(PlayerInput obj)
    {
        PlayerController player = obj.GetComponent<PlayerController>();

        player.selectOption = playerSelectMenu.players[players.Count];
        player.playerID = (uint)players.Count;

        DontDestroyOnLoad(player);

        playerSelectMenu.players[players.Count].PlayerJoin();

        players.Add(player);
        InspectorName(player.gameObject, "Player" + players.Count);
    }

    public static void InspectorName(GameObject gameObject, string name)
    {
#if UNITY_EDITOR
        gameObject.name = name;
#endif
    }
}
