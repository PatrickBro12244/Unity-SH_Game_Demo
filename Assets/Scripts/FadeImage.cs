using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : MonoBehaviour
{
    public Animator fade;
    public GameObject Image;
    public bool played;
    public float timer = 0f;
    public GameObject scare;
    private bool InTrigger = false;
    public bool taken = false;
  
   
    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(false);
        scare.SetActive(false);
    }
    void Update()
    {
        if(played)
        {
            timer += 1 * Time.deltaTime;
        }
        if(InTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && !played && !taken)
            {

                Image.SetActive(true);
                fade.ResetTrigger("FadeOut");
                fade.SetTrigger("FadeIn");
                played = true;
              

            }
            else if (Input.GetKeyDown(KeyCode.E) && played && !taken)
            {
                fade.SetTrigger("FadeOut");
                fade.ResetTrigger("FadeIn");
                played = false;
                timer = 0f;
            }

            if(taken)
            {
                scare.SetActive(true);
            }
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            InTrigger = true;
           

        }
       
    }
    void OnTriggerExit(Collider other)
    {
       
        fade.SetTrigger("FadeOut");
        fade.ResetTrigger("FadeIn");
        played = false;
        timer = 0f;
        InTrigger = false;


    }
    // Update is called once per frame

}
