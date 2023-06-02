using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMicrowave : MonoBehaviour
{
    public CharacterMovement script;
 
    

    public GameObject textS;
    public GameObject textF;
    public GameObject textL;
    public GameObject textLL;
    public Animator MicrowaveA;
    public Animator creepScare;
    public GameObject Soap;
    public GameObject SoapKey;
    public GameObject PickupKey;
    public GameObject MicrowaveLight;
    public AudioSource equip;
    public AudioSource Microwave;
    public AudioSource creepScareSound;
    public AudioSource grab;
    public GameObject PickupTrig;
    
    public bool inside;
    public bool gotten = false;
    private bool unlocked = false;
    private bool soundplayed = false;
    private bool soundplayed2 = false;
    private bool done = false;
    private bool soundplayed3 = false;

    void Start()
    {
        MicrowaveLight.SetActive(false);
        Soap.SetActive(false);
        SoapKey.SetActive(false);
        textS.SetActive(false);
        PickupKey.SetActive(false);
        textF.SetActive(false);
        textL.SetActive(true);
        PickupTrig.SetActive(false);

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;



            if ((script.usedItem) && (script.ItemCode == 2))
            {
                Destroy(textL);

                if (!soundplayed)
                {
                    equip.Play();
                    Soap.SetActive(true);
                    SoapKey.SetActive(true);
                    textLL.SetActive(false);
                    textL.SetActive(false);
                    textF.SetActive(false);
                    unlocked = true;
                    soundplayed = true;
                    textS.SetActive(true);
                }

            }
            else if ((script.usedItem) && (script.ItemCode != 2))
            {
                textF.SetActive(true);
                textLL.SetActive(false);
                //textL.SetActive(false);
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
                
                textF.SetActive(false);
            }
            else
            {
                
                if (!soundplayed2)
                {
                    MicrowaveA.SetBool("PlayAnim", true);
                    soundplayed2 = true;
                    
                    MicrowaveLight.SetActive(true);
                    Microwave.Play();
                    creepScare.SetBool("Trig", true);
                    creepScareSound.Play();
                    Destroy(Soap, Microwave.clip.length - 1f);
                    Destroy(MicrowaveLight, Microwave.clip.length - 1f);

                  
                }

            }
            if (Soap == null)
            {
                PickupKey.SetActive(true);
                PickupTrig.SetActive(true);

                done = true;
            }
            if(done && !soundplayed3)
            {
                grab.PlayDelayed(2f);
                soundplayed3 = true;
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
            textLL.SetActive(false);
            //textL.SetActive(false);


        }


    }

}
