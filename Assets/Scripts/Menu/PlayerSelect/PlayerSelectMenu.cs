using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (CheckAllReady())
            GameController.instance.StartMatch();
    }

    bool CheckAllReady()
    {
        if (GameController.GetPlayerInputManager().playerCount != GameController.GetPlayerInputManager().maxPlayerCount)
            return false;

        foreach (PlayerSelectOption option in players)
        {
            if (!option.isReady)
                return false;
        }

        return true;
    }
}
