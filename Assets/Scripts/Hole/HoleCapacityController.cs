using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCapacityController : MonoBehaviour
{
    [SerializeField] private GameObject fullCircle;
    public int holeCapacity { get; set; } = 5;   

    private void Update()
    {
        CapacityControl();
    }

    private void CapacityControl()
    {
        if (CollectibleItem.collectedTotalItemCount>=holeCapacity)
        {
            fullCircle.SetActive(true);
        }
        else
        {
            fullCircle.SetActive(false);
        }
    }   
}
