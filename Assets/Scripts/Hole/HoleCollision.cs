using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoleCollision : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyTextPrefab;
    [SerializeField] private GameObject moneyCanvas;
    public int currentMoney;
    private Vector3 textPos;
       

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            if (CollectibleItem.soldGoldCount > 0)
            {
                for (int i = 0; i < CollectibleItem.soldGoldCount; i++)
                {
                    currentMoney += CollectibleItem.goldMoneyValue;
                    moneyTextPrefab.text = "+" + CollectibleItem.goldMoneyValue.ToString();
                    TextMeshProUGUI newGoldText = Instantiate(moneyTextPrefab, gameObject.transform.position + TextRandomPos(), moneyCanvas.transform.rotation, moneyCanvas.transform);                    
                    Destroy(newGoldText.transform.gameObject, 1f);
                    CollectibleItem.soldGoldCount--;
                }
            }
            else if (CollectibleItem.soldSilverCount > 0)
            {
                for (int i = 0; i < CollectibleItem.soldSilverCount; i++)
                {
                    currentMoney += CollectibleItem.silverMoneyValue;
                    moneyTextPrefab.text = "+" + CollectibleItem.silverMoneyValue.ToString();
                    TextMeshProUGUI newSilverText= Instantiate(moneyTextPrefab, gameObject.transform.position + TextRandomPos(), moneyCanvas.transform.rotation, moneyCanvas.transform);
                    Destroy(newSilverText.transform.gameObject, 1f);                    
                    CollectibleItem.soldSilverCount--;
                }
            }
            else if (CollectibleItem.soldRedCrystalCount > 0)
            {
                for (int i = 0; i < CollectibleItem.soldRedCrystalCount; i++)
                {
                    currentMoney += CollectibleItem.redCrystalMoneyValue;
                    moneyTextPrefab.text = "+" + CollectibleItem.redCrystalMoneyValue.ToString();
                    TextMeshProUGUI newRedCrystalText = Instantiate(moneyTextPrefab, gameObject.transform.position + TextRandomPos(), moneyCanvas.transform.rotation, moneyCanvas.transform);
                    Destroy(newRedCrystalText.transform.gameObject, 1f);
                    CollectibleItem.soldRedCrystalCount--;
                }
            }
            else if (CollectibleItem.soldGemstoneCount > 0)
            {
                for (int i = 0; i < CollectibleItem.soldGemstoneCount; i++)
                {
                    currentMoney += CollectibleItem.gemstoneMoneyValue;
                    moneyTextPrefab.text = "+" + CollectibleItem.gemstoneMoneyValue.ToString();
                    TextMeshProUGUI newGemstoneText = Instantiate(moneyTextPrefab, gameObject.transform.position + TextRandomPos(), moneyCanvas.transform.rotation, moneyCanvas.transform);
                    Destroy(newGemstoneText.transform.gameObject, 1f);
                    CollectibleItem.soldGemstoneCount--;
                }
            }
        }        
    }   
    
    private Vector3 TextRandomPos()
    {
        float randomPosX = Random.Range(-0.5f, 0.5f);
        float randomPosZ = Random.Range(-0.5f, 0.5f);
        float randomPosY = Random.Range(0.5f, 0.8f);
        textPos = new Vector3(randomPosX, randomPosY, randomPosZ);
        return textPos;
    }
}
