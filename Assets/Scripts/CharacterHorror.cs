using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHorror : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float grav;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private AudioSource FootSoundSoft;
    [SerializeField] private AudioSource FootSoundHard;
    private float footdelay = 0.2f;
    private float nextsteps = 0;
    

    private Vector3 slidingDirection;

    
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         RaycastHit hit;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
       
        Vector3 forwardmove = transform.forward * vertical;
        Vector3 rightmove = transform.right * horizontal;
        controller.Move(Vector3.ClampMagnitude(forwardmove + rightmove, 1f) * speed * Time.deltaTime);
        velocity.y += grav * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            grav = 0;
            
            


            if (controller.velocity.magnitude != 0)
            {
                nextsteps -= Time.deltaTime;

                if (Physics.Raycast(transform.position, Vector3.down, out hit))

                {

                    if (nextsteps <= 0)
                {
                   



                        if (hit.collider.tag == "Fsoft")
                        {
                            //Debug.Log("floor");
                            FootSoundSoft.Play();
                            nextsteps += footdelay;
                        }
                        else if (hit.collider.tag == "Fhard")
                        {
                            FootSoundHard.Play();
                            nextsteps += footdelay;
                        }


                    }
                }
            }







        }
    }

}

        
    






    

   