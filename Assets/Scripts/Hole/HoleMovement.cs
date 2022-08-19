using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    public float moveSpeed { get; set; } = 1.0f;    

    private float horizontal;
    private float vertical;
    private Vector3 addedPos;    
    public float boundaryXValue { get; set; } = 1.6f;
    public float boundaryZValue { get; set; } = 2.6f;
    private float boundaryPosX;
    private float boundaryPosZ;
    private Vector3 boundaryPos;
    

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HoleMovementControl();            
        }
    }

    private void HoleMovementControl()
    {
        horizontal = floatingJoystick.Horizontal;
        vertical = floatingJoystick.Vertical;

        addedPos = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, vertical * moveSpeed * Time.deltaTime);
        transform.position += addedPos;
        transform.position= HoleMovementBoundary();
    }

    private Vector3 HoleMovementBoundary()
    {
        boundaryPosX = Mathf.Clamp(transform.position.x, -boundaryXValue, boundaryXValue);
        boundaryPosZ = Mathf.Clamp(transform.position.z, -boundaryZValue, boundaryZValue);

        boundaryPos = new Vector3(boundaryPosX, transform.position.y, boundaryPosZ);
        return boundaryPos;
    }
}
