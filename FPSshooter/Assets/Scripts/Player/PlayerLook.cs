using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    //public Transform Gun;
    public Camera Cam;
    private float xRotation=0f;

    public float xSensivity = 30f;
    public float ySensivity = 30f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ProcessLook(Vector2 input)
    {
        float mouseX=input.x;
        float mouseY=input.y;   

        xRotation-=(mouseY*Time.deltaTime)*ySensivity;
        xRotation=Mathf.Clamp(xRotation, -50f, 50f);

        Cam.transform.localRotation=Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensivity);

        
        //Gun.localRotation=Quaternion.Euler(xRotation, 0f, 0f);

    }
}
