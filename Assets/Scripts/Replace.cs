using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enable;
    public GameObject disable;
  
    void Start()
    {
        enable.SetActive(false);

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enable.SetActive(true);
            disable.SetActive(false);
        }
    }
}
