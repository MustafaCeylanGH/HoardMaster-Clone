using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeArea : MonoBehaviour
{
    [SerializeField] private GameObject upgradeCanvas;
    [SerializeField] private TextMeshProUGUI upSpeedMoneyText;
    [SerializeField] private TextMeshProUGUI upRadiusMoneyText;
    [SerializeField] private TextMeshProUGUI upCapacityMoneyText;
    [SerializeField] private Button upSpeedButton;
    [SerializeField] private Button upRadiusButton;
    [SerializeField] private Button upCapacityButton;

    private HoleVertices holeVertices;
    private HoleMovement holeMovement;
    private HoleCapacityController holeCapacityController;
    private GameManager gameManager;
    private int upSpeedPrice = 15;
    private int upRadiusPrice = 20;
    private int upCapacityPrice = 15;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        holeVertices = FindObjectOfType<HoleVertices>();
        holeMovement = FindObjectOfType<HoleMovement>();
        holeCapacityController = FindObjectOfType<HoleCapacityController>();
    }

    private void Update()
    {
        if (gameManager.currentMoney >= upSpeedPrice)
        {
            upSpeedButton.interactable = true;
            upSpeedMoneyText.color = Color.green;
        }
        else
        {
            upSpeedButton.interactable = false;
            upSpeedMoneyText.color = Color.red;
        }
        
        if(gameManager.currentMoney >= upRadiusPrice)
        {
            upRadiusButton.interactable = true;
            upRadiusMoneyText.color = Color.green;
        }
        else
        {
            upRadiusButton.interactable = false;
            upRadiusMoneyText.color = Color.red;
        }
        
        if (gameManager.currentMoney >= upCapacityPrice)
        {
            upCapacityButton.interactable = true;
            upCapacityMoneyText.color = Color.green;
        }
        else
        {        
            upCapacityButton.interactable = false;
            upCapacityMoneyText.color = Color.red;
        }

    }
    public void UpSpeedHole()
    {       
        upSpeedButton.interactable = true;
        holeMovement.moveSpeed += 0.3f;
        gameManager.currentMoney -= upSpeedPrice;
        upSpeedPrice += 5;
        upSpeedMoneyText.text = "$" + upSpeedPrice.ToString();
    }

    public void UpRadiusHole()
    {
        holeVertices.UpScaleHole();
        gameManager.currentMoney -= upRadiusPrice;
        upRadiusPrice += 5;
        upRadiusMoneyText.text = "$" + upRadiusPrice.ToString();
    }

    public void UpCapacityHole()
    {
        holeCapacityController.holeCapacity += 1;
        gameManager.currentMoney -= upCapacityPrice;
        upCapacityPrice += 5;
        upCapacityMoneyText.text = "$" + upCapacityPrice.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            upgradeCanvas.SetActive(true);
        }            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            upgradeCanvas.SetActive(false);
        }
    }
}
