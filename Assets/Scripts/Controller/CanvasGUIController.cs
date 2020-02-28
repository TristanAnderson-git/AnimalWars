using UnityEngine;
using System.Collections;
using TMPro;

public class CanvasGUIController : MonoBehaviour
{
    public TextMeshProUGUI foodText;

    private void Start()
    {
        AddFood(0, 250);
    }

    public void AddFood(int currentAmount, int amount)
    {
        int newAmount = currentAmount + amount;
        StartCoroutine(UpdateGUI(foodText, currentAmount, newAmount));
    }

    IEnumerator UpdateGUI(TextMeshProUGUI text, int currentAmount, int newAmount)
    {
        int increment = (int)Mathf.Sign(newAmount - currentAmount);

        while (currentAmount != newAmount)
        {
            currentAmount += increment;
            text.SetText("Food: " + currentAmount.ToString());
            yield return new WaitForEndOfFrame();
        }
    }
}
