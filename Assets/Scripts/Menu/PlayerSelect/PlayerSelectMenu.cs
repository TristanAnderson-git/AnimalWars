using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSelectMenu : MonoBehaviour
{
    public GameObject playerSelectionUI;
    public GameObject playerSelectContainer;

    [Space]
    public Color[] playerColours = new Color[4];

    [HideInInspector]
    public PlayerSelectOption[] players;

    void Start()
    {
        GameController.players = new List<GameObject>();
        
        SetUpPlayerSelect();
    }

    void SetUpPlayerSelect()
    {
        int maxPlayers = GameController.GetPlayerInputManager().maxPlayerCount;
        players = new PlayerSelectOption[maxPlayers];

        for (int i = 0; i < maxPlayers; i++)
        {
            players[i] = Instantiate(playerSelectionUI, playerSelectContainer.transform).GetComponent<PlayerSelectOption>();
            players[i].SetPlayerName("Player " + (i + 1));
            players[i].background.color = playerColours[i];
        }
    }

    void Update()
    {
        if (GameController.GetPlayerInputManager().playerCount == GameController.GetPlayerInputManager().maxPlayerCount)
            GameController.instance.StartMatch();
    }
}
