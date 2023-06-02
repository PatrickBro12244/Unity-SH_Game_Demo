using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playonce : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound;
    private bool played = false;

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!played)
            {
                sound.Play();
                played = true;
            }
        }
    }
}
