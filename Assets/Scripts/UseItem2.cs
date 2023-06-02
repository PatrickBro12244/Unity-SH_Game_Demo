using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem2 : MonoBehaviour
{
    public CharacterMovement script;
    public FadeImage script2;
    public GameObject scare;
   
    public GameObject textS;
    public GameObject textF;
   // public GameObject textL;
    public GameObject View;
    public GameObject newItem;
    public AudioSource equip;
    public AudioSource grab;
    public GameObject water;
    public bool inside;
    public bool gotten = false;
    private bool unlocked = false;
    private bool soundplayed = false;
    private bool soundplayed2 = false;
    void Start()
    {
        newItem.SetActive(false);
        textS.SetActive(false);
        textF.SetActive(false);
        //textL.SetActive(false);
        scare.SetActive(false);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;



            if ((script.usedItem) && (script.ItemCode == 1))
            {
                View.SetActive(false);
                script2.taken = true;
                script2.Image.SetActive(false);
                newItem.SetActive(true);
               
                unlocked = true;
                textF.SetActive(false);
                if (!soundplayed)
                {
                    equip.Play();
                   
                    soundplayed = true;
                }
                
            }
            else if ((script.usedItem) && (script.ItemCode != 1))
            {
                textF.SetActive(true);
               // textL.SetActive(false);
            }





        }
        else
        {
            inside = false;
        }


    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!unlocked)
            {
                //textL.SetActive(true);
                textF.SetActive(false);
            }
            else
            {
                textS.SetActive(true);
                if (!soundplayed2)
                {
                    Destroy(View);
                    equip.Play();
                    Destroy(water);
                    grab.Play();
                    scare.SetActive(true);
                    soundplayed2 = true;
                    gotten = true;
                   
                }

            }

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gotten)
            {
                Destroy(gameObject);
            }

            inside = false;
            script.usedItem = false;
            textS.SetActive(false);
            textF.SetActive(false);
            //textL.SetActive(false);
            
           
        }
        

    }
}
