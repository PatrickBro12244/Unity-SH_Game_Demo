using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public Camera AreaCam;
    public Camera MainCam;
    public Transform campiv;
    public bool Cam2;

    void start()
    {
        Cam2 = false;
        AreaCam.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainCam.enabled = false;
            AreaCam.enabled = true;
            Cam2 = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainCam.enabled = true;
            AreaCam.enabled = false;
            Cam2 = false;
        }

    }
}
