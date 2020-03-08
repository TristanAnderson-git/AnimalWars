using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static List<GameObject> players;

    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    
    public int numberOfPlayers;

    void Start()
    {
        // create singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        StartMatch();
    }

    void Update()
    {
        if (players.Count <= 1)
            EndMatch();
    }

    public void StartMatch()
    {
        SetupPlayers();
    }

    public void EndMatch()
    {

    }

    private void SetupPlayers()
    {
        players = new List<GameObject>();
        
        PlayerInputManager playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput obj)
    {
        GameObject player = obj.gameObject;
        players.Add(player);
        InspectorName(player, "Player" + GameController.players.Count);

        GameObject camera = Instantiate(cameraPrefab);
        camera.GetComponent<CameraController>().SetUp(GameController.players.Count - 1, numberOfPlayers, player.transform);
        InspectorName(camera, "Player" + GameController.players.Count + " Camera");
    }

    private void InspectorName(GameObject gameObject, string name)
    {
#if UNITY_EDITOR
        gameObject.name = name;
#endif
    }
}
