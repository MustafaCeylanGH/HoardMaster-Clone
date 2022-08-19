using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentMoneyText;
    [SerializeField] private GameObject levelCompletedCanvas;
    public int currentMoney { get; set; }

    private void Update()
    {
        currentMoneyText.text = currentMoney.ToString();

        if (CollectibleItem.itemsCount==28)
        {
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        levelCompletedCanvas.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
