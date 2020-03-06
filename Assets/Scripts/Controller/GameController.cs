using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    public GameObject gameUIPrefab;

    public int numberOfPlayers;

    public int remainingPlayers;

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
        if (remainingPlayers <= 1)
            EndMatch();
    }

    public void StartMatch()
    {
        StartCoroutine(SetupPlayers());
    }

    public void EndMatch()
    {

    }

    private IEnumerator SetupPlayers()
    {
        bool finished = false;

        while(!finished)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                GameObject player = Instantiate(playerPrefab);
                InspectorName(player, "Player" + (i + 1));

                GameObject camera = Instantiate(cameraPrefab);
                camera.GetComponent<CameraController>().SetUp(i, numberOfPlayers, player.transform);
                InspectorName(camera, "Player" + (i + 1) + "_Camera");

                GameObject ui = Instantiate(gameUIPrefab);
                ui.GetComponent<Canvas>().worldCamera = camera.GetComponent<Camera>();
                ui.GetComponent<Canvas>().planeDistance = 0;
                InspectorName(ui, "Player" + (i + 1) + "_Canvas");

                yield return new WaitForEndOfFrame();
            }

            finished = true;
        }
    }

    private void InspectorName(GameObject gameObject, string name)
    {
#if UNITY_EDITOR
        gameObject.name = name;
#endif
    }
}
