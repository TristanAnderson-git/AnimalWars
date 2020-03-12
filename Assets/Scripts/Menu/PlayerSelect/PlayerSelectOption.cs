using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSelectOption : MonoBehaviour
{
    public Image background;
    public GameObject join;
    public GameObject character;
    public GameObject ready;
    public TextMeshProUGUI playerName;

    public bool isReady = false;

    public void SetReady(bool isReady)
    {
        if (ready != null)
        {
            ready.SetActive(isReady);
            this.isReady = isReady;
        }
    }

    public void PlayerJoin()
    {
        join.SetActive(false);
        character.SetActive(true);
    }

    public void SetPlayerName(string name)
    {
        playerName.SetText(name);
    }
}
