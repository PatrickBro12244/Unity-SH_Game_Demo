using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOvChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        cam.fieldOfView = 40;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            cam.fieldOfView = 55;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
