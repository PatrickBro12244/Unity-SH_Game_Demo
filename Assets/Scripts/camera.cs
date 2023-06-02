using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour

{


    public float rotatespeed;
 public Transform Character;
    float xRotation = 0f;
 
 void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotatespeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotatespeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Character.Rotate(Vector3.up * mouseX);


    }
}

