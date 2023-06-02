using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public AudioSource Locked;
    public bool seen = false;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Locked.Play();
                seen = true;

                }
          

        }
    }
}
