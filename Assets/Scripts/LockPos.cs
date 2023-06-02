using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPos : MonoBehaviour
{
    public Camera cam;
    public float lockPos;
   

    void start()
    {
        //cam = Camera.main;

    }
    void Update()
    {
        // Locks the rotation.
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.y, lockPos, lockPos);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.z, lockPos, lockPos);

        transform.LookAt(cam.transform);



        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
