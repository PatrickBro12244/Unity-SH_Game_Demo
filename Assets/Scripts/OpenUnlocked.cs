using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUnlocked : MonoBehaviour
{
    public GameObject fade;
    public AudioSource open;
    public bool inside = false;
    // Start is called before the first frame update
    void Start()
    {
        fade.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            inside = true;
        }
        
    }


    void Update()
    {
        if(inside)
        {
            if(Input.GetKey(KeyCode.E))
            {
                open.Play();
                fade.SetActive(true);
            }
        }
    }
}
