using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPickupDel : MonoBehaviour
{
    public GameObject text;
    public GameObject Del;
    public GameObject Del2;
    public GameObject Scare;
    void Awake()
    {
        text.SetActive(false);
        Scare.SetActive(false);
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
            Scare.SetActive(true);
            text.SetActive(false);
            Destroy(gameObject);
            Destroy(Del);
            Destroy(Del2);

        }
    }
}
