using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            CollectibleItem.collectedGoldCount++;
            CollectibleItem.collectedTotalItemCount++;
            CollectibleItem.itemsCount++;
            GameObject goldParent = other.transform.parent.gameObject;
            Destroy(goldParent);
        }
        else if (other.gameObject.CompareTag("Silver"))
        {
            CollectibleItem.collectedSilverCount++;
            CollectibleItem.collectedTotalItemCount++;
            CollectibleItem.itemsCount++;
            GameObject silverParent = other.transform.parent.gameObject;
            Destroy(silverParent);
        }
        else if (other.gameObject.CompareTag("RedCrystal"))
        {
            CollectibleItem.collectedRedCrystalCount++;
            CollectibleItem.collectedTotalItemCount++;
            CollectibleItem.itemsCount++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Gemstone"))
        {
            CollectibleItem.collectedGemstoneCount++;
            CollectibleItem.collectedTotalItemCount++;
            CollectibleItem.itemsCount++;
            Destroy(other.gameObject);
        }
    }   
}
