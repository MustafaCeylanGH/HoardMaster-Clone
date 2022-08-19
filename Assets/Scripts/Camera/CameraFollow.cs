using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform holeCenter;
    [SerializeField] private float smootheValue;
    private float offsetX;
    private float offsetZ;
    private Vector3 targetPos;
    

    private void Awake()
    {
        offsetX = holeCenter.position.x - transform.position.x;
        offsetZ = holeCenter.position.z - transform.position.z;
    }
    private void LateUpdate()
    {
        CameraFollowControl();
    }

    private void CameraFollowControl()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPosCalculate() ,smootheValue * Time.deltaTime);
    }

    private Vector3 TargetPosCalculate()
    {
        targetPos = new Vector3(holeCenter.position.x-offsetX, transform.position.y, holeCenter.position.z-offsetZ);
        return targetPos;
    }
}
