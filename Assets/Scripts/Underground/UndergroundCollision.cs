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
            GameObject goldParent = other.transform.parent.gameObject;
            Destroy(goldParent);
        }
        else if (other.gameObject.CompareTag("Silver"))
        {
            CollectibleItem.collectedSilverCount++;
            CollectibleItem.collectedTotalItemCount++;
            GameObject silverParent = other.transform.parent.gameObject;
            Destroy(silverParent);
        }
        else if (other.gameObject.CompareTag("RedCrystal"))
        {
            CollectibleItem.collectedRedCrystalCount++;
            CollectibleItem.collectedTotalItemCount++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Gemstone"))
        {
            CollectibleItem.collectedGemstoneCount++;
            CollectibleItem.collectedTotalItemCount++;
            Destroy(other.gameObject);
        }
    }   
}
