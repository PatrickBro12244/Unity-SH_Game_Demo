using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPickup : MonoBehaviour
{
    public GameObject text;


    void Start()
    {
        text.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                text.SetActive(true);

            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            text.SetActive(false);
            Destroy(gameObject);


        }
    }
}
