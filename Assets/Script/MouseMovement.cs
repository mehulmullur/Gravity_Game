using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    float rotationX = 0f, rotationY = 0f;

    float sensitivity = 5f; 

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity; //Mouse horizontal input
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity; // Mouse vertical Input
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
