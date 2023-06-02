using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject L1;
    public GameObject L2;
    //public GameObject L3;
   // public GameObject L4;
    public bool on;
    [SerializeField] private AudioSource Ssound;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        L1.SetActive(false);
        L2.SetActive(false);
        //L3.SetActive(false);
        //L4.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                if (!on)
                {
                    L1.SetActive(true);
                    L2.SetActive(true);
                   // L3.SetActive(true);
                    //L4.SetActive(true);
                    on = true;
                    Ssound.Play();
                }
                else
                {
                    L1.SetActive(false);
                    L2.SetActive(false);
                    //L3.SetActive(false);
                    //L4.SetActive(false);
                    on = false;
                    Ssound.Play();
                }
                
            }
            
        }
    }
    

    
    
}
