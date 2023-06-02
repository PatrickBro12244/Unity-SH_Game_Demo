using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   
    public CharacterMovement script;

    public GameObject fade;
    public GameObject textS;
    public GameObject textF;
    public GameObject textL;
    public AudioSource locked;
    public AudioSource open;
    public AudioSource opendoor;
    public bool inside;
    private bool unlocked = false;
    private bool soundplayed = false;

    void Start()
    {
        textS.SetActive(false);
        textF.SetActive(false);
        textL.SetActive(false);
        fade.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;


           
                if ((script.usedItem) && (script.ItemCode == 1) )
                {
                    if (!soundplayed)
                    {
                        open.Play();
                        soundplayed = true;
                    }
                    textS.SetActive(true);
                    unlocked = true;

                    textL.SetActive(false);
                    textF.SetActive(false);
                }
                  else if ((script.usedItem) && (script.ItemCode != 1) )
                {
                    textF.SetActive(true);
                     textL.SetActive(false);
                }
            

            if (Input.GetKey(KeyCode.E))
            {
                if (!unlocked)
                {
                    locked.Play();
                    textL.SetActive(true);
                    textF.SetActive(false);
                }
                else
                {
                    fade.SetActive(true);
                    opendoor.Play();
                }

            }

                

        }
        else
        {
            inside = false;
        }
        
      
    }
    void Update()
    {

       

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textS.SetActive(false);
            textF.SetActive(false);
            textL.SetActive(false);
            inside = false;
            script.usedItem = false;
        }
    }
}
