using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beautyscene : MonoBehaviour
{
    public AudioSource soundtrack;
    public GameObject snow;
    // Start is called before the first frame update
    void Start()
    {
        snow.SetActive(false);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            snow.SetActive(true);
            soundtrack.Play();
            Destroy(gameObject);
}
    }

    // Update is called once per frame
   
}
