using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scare1 : MonoBehaviour
{
    public LockedDoor script;
    public GameObject door;
    public AudioSource scare;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(script.seen)
            {
                scare.Play();
                door.SetActive(false);
                script.seen = false;


            }
        }
    }
}
