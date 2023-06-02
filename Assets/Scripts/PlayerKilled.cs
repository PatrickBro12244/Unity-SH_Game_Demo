using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKilled : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterMovement Character;
    public EnemyFollow speed;
    public AudioSource hit;
    public AudioSource hit2;
    public float MovSpeed;
    public float timer = 0f;
    public float cooldown = 2f;


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (timer <= 0)
            {
                Character.health -= 10;
                
                hit.Play();
                hit2.Play();
                speed.nav.speed = 0f;
                timer = cooldown;
               
            }
           
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (timer <= 0)
            {
                Character.health -= 10;
                
                hit.Play();
                hit2.Play();
                speed.nav.speed = 0f;
                timer = cooldown;

            }

        }

    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= 2f * Time.deltaTime;
        }
        if (timer <= 0)
        {
            speed.nav.speed = MovSpeed;
        }
    }
}
