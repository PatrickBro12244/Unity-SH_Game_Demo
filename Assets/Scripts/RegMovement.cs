using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegMovement : MonoBehaviour
{

    public bool tankControls = true;
    public Animator animator;

    // Speeds
    public float speed;
    public float stamina = 100;
    float currentspeed;
    public float gravity = 9.18f;


    float walkspeed = 3.0f;
    float runspeed = 0.005f;
    float backspeed = 1.5f;
    float turnspeed = 150f;
    float aimspeed = 1.5f;
    public Vector2 look;

    float horizontalInput;
    float verticalInput;

    // States
    public bool isWalking;
    bool runPressed;
    public bool isRunning;
    public bool movingForward = false;
    public bool movingBackward = false;

    // References
    Character player;
    CharacterController characterController;
    public GameObject gameCamera;
    public Transform Front;

    void Start()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;
        player = GetComponent<Character>();
        characterController = GetComponent<CharacterController>();
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera");

    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        runPressed = Input.GetKey(KeyCode.LeftShift);

        if (!player.isAiming)
        {

            //Horizontal

            if (horizontalInput > 0)
            {
                horizontalInput = 1;
            }
            else if (horizontalInput < 0)
            {
                horizontalInput = -1;
            }
            else
            {
                horizontalInput = 0;
            }

            //Vertical

            if (verticalInput > 0)
            {
                verticalInput = 1;
            }
            else if (verticalInput < 0)
            {
                verticalInput = -1;
            }
            else
            {
                verticalInput = 0;
            }

        }


        if (!player.stopInput)
        {
          
                float h = horizontalInput * Time.deltaTime * turnspeed;
                float v = verticalInput * Time.deltaTime * speed;

            float Rotation;

            Rotation = Front.eulerAngles.y;
            Move(h, v);
           

        }

        

        if (verticalInput > 0)
        {
            if (!movingForward)
            {
                movingForward = true;
            }
        }
        else if (verticalInput < 0)
        {
           
           
                movingForward = true;
 

        }

      
        else
        {
            movingForward = false;
        }
        if (runPressed && stamina > 0)
        {
            isRunning = true;
            speed += runspeed;
            stamina -= 0.05f;
        }
        else if (runPressed && stamina < 0)
        {
            if (speed > backspeed)
            {
                speed -= 0.01f;
                isRunning = false;
            }
        }
        else
        {
            if (stamina < 100)
                stamina += 0.05f;

            speed = walkspeed;
            isRunning = false;
        }











    }



    void Move(float h, float v)
    {
          animator.SetFloat("Speed", Mathf.Abs(v) * speed);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);



        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 10000f * Time.deltaTime);
        }


        if (!characterController.isGrounded)
        {
            movementDirection.y -= gravity;
        }
        else
        {
            movementDirection.y = 0f;
        }

        characterController.Move(movementDirection * speed * Time.deltaTime);






    }
}


