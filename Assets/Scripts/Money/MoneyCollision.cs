using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyCollision : MonoBehaviour
{  
    private MoneySpawner moneySpawner;

    private void Awake()
    {        
        moneySpawner = FindObjectOfType<MoneySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("UnderGround"))
        {
            moneySpawner.money.Remove(gameObject);
            CollectibleItem.soldTotalItemCount--;
            Destroy(gameObject);
        }
    }
}