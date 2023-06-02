using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool pickup1 = false;
    public bool pickup2 = false;
    public bool pickup3 = false;
    public bool pickup4 = false;
    public bool pickup5 = false;
    public bool pickup6 = false;
    public bool pickup7 = false;
    public bool pickup8 = false;
    public GameObject Item;
    public AudioSource PickupS;
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
           
            GameObject.Destroy(Item);

            PickupS.Play();

            if(Item.tag == "key1")
            {
                pickup1 = true;
            }
            else if (Item.tag == "key2")
            {
                pickup2 = true;
            }
            else if (Item.tag == "key3")
            {

            }
            else if (Item.tag == "key4")
            {

            }
            else if (Item.tag == "key5")
            {

            }
            else if (Item.tag == "key6")
            {

            }
            else if (Item.tag == "key7")
            {

            }
            else if (Item.tag == "key8")
            {

            }
        }


    }
}
