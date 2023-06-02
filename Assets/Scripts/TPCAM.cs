using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCAM : MonoBehaviour
{

    public Transform TP;
    public GameObject Cam;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cam.transform.position = TP.transform.position;
            Cam.transform.rotation = TP.transform.rotation;
        }
    }

    
}
