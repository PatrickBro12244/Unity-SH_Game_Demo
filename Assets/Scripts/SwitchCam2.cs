using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam2 : MonoBehaviour
{
    public MixedCam script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            script.look = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
       
            script.look = false;
        
    }
}
