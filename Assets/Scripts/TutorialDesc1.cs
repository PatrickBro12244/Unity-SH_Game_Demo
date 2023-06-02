using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDesc1 : MonoBehaviour
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

            text.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            text.SetActive(false);


        }
    }
}
