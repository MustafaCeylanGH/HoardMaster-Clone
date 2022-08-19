using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArea : MonoBehaviour
{    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {           
            if (CollectibleItem.collectedGoldCount > 0)
            {
                for (int i = 0; i < CollectibleItem.collectedGoldCount; i++)
                {
                    CollectibleItem.collectedGoldCount--;
                    CollectibleItem.soldGoldCount++;
                    CollectibleItem.collectedTotalItemCount--;
                    CollectibleItem.soldTotalItemCount++;                    
                }
            }
            else if (CollectibleItem.collectedSilverCount > 0)
            {
                for (int i = 0; i < CollectibleItem.collectedSilverCount; i++)
                {
                    CollectibleItem.collectedSilverCount--;
                    CollectibleItem.soldSilverCount++;
                    CollectibleItem.collectedTotalItemCount--;
                    CollectibleItem.soldTotalItemCount++;                    
                }
            }
            else if (CollectibleItem.collectedRedCrystalCount > 0)
            {
                for (int i = 0; i < CollectibleItem.collectedRedCrystalCount; i++)
                {
                    CollectibleItem.collectedRedCrystalCount--;
                    CollectibleItem.soldRedCrystalCount++;
                    CollectibleItem.collectedTotalItemCount--;
                    CollectibleItem.soldTotalItemCount++;                   
                }
            }
            else if (CollectibleItem.collectedGemstoneCount > 0)
            {
                for (int i = 0; i < CollectibleItem.collectedGemstoneCount; i++)
                {
                    CollectibleItem.collectedGemstoneCount--;
                    CollectibleItem.soldGemstoneCount++;
                    CollectibleItem.collectedTotalItemCount--;
                    CollectibleItem.soldTotalItemCount++;                   
                }
            }
        }
    }

}
