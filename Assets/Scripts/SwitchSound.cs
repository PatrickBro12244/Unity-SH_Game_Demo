using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    public AudioSource newsound;
    public AudioSource oldsound;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            oldsound.Stop();
            newsound.Play();

        }
        
    }

   
}
