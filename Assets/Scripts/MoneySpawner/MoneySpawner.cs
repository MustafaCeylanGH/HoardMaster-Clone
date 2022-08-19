using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField] private Transform spawnPos;
    public List<GameObject> money  = new List<GameObject>();


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

                if (i >= 1 && i != 6 && i != 12)
                {
                    money[i].transform.position = money[i - 1].transform.position + new Vector3(0.1f, 0, 0);
                }
                else if (i == 0)
                {
                    money[i].transform.position = spawnPos.position;
                }
                else if (i == 6 || i == 12)
                {
                    money[i].transform.position = spawnPos.position + new Vector3(0, 0.04f, 0);
                }

            }
        }
    }
}

