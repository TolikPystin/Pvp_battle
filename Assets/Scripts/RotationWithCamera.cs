using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWithCamera : MonoBehaviour
{
    private float horizontalspeed = 10f;
    private float verticalspeed = 10f;
    private float minangle = -45;
    private float maxangle = 45f;
    private float rotationX, rotationY;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * verticalspeed;
        rotationX = Mathf.Clamp(rotationX, minangle, maxangle);
        float delta = Input.GetAxis("Mouse X") * horizontalspeed;
        rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
    }
}
