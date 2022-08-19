using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;    
    public List<GameObject> money { get; set; } = new List<GameObject>();


    private void Update()
    {
        SpawnMoney();       
    }

    private void SpawnMoney()
    {
        if (CollectibleItem.soldTotalItemCount > 0)
        {
            for (int i = money.Count; i < CollectibleItem.soldTotalItemCount; i++)
            {
                GameObject newMoney = Instantiate(moneyPrefab);
                money.Add(newMoney);

                if (i >= 1 && i != 5 && i != 11)
                {
                    money[i].transform.position = money[i - 1].transform.position + new Vector3(0.1f, 0, 0);
                }
                else if (i == 0)
                {
                    money[i].transform.position = transform.position;
                }
                else if (i == 5 || i == 11)
                {
                    money[i].transform.position = transform.position+ new Vector3(0, 0.04f, 0);
                }

            }
        }
    }
}

