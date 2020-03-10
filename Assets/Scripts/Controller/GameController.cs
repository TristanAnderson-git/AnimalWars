using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static List<GameObject> players;

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
        SceneManager.sceneLoaded += SetupPlayers;
    }

    public static void EndMatch()
    {

    }

    private void SetupPlayers(Scene scene, LoadSceneMode mode)
    {
        for (int i = 0; i < players.Count; i++)
        {
            GameObject camera = Instantiate(cameraPrefab);
            camera.GetComponent<CameraController>().SetUp(i, players.Count, players[i].transform);
            InspectorName(camera, "Player" + players.Count + " Camera");
        }
    }

    public void OnPlayerJoined(PlayerInput obj)
    {
        GameObject player = obj.gameObject;
        DontDestroyOnLoad(player);

        players.Add(player);
        InspectorName(player, "Player" + players.Count);

        playerSelectMenu.players[players.Count - 1].PlayerJoin();
    }

    public static void InspectorName(GameObject gameObject, string name)
    {
#if UNITY_EDITOR
        gameObject.name = name;
#endif
    }
}
