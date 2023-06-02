using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterMovement script;
    public GameObject Item;
    public AudioSource Pickup;
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {

            GameObject.Destroy(Item);

            script.FlashlightTaken = true;

            Pickup.Play();
        }


    }
}
