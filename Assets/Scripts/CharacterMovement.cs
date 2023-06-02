using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{

    public int ItemCode = 0;
    public Color orange = new Color(0.2F, 0.3F, 0.4F);
    public bool usedItem;
    public bool tankControls = true;
    public Animator animator;
    public RawImage Status;
    public GameObject GameOver;
   
    // Speeds
    public float speed;
    float currentspeed;
    float gravity = 20f;
   

    public float walkspeed = 2f;
    public float runspeed = 5f;
    public float backspeed = 0.5f;
    public float turnspeed = 150f;
    public float aimspeed = 1.5f;
    public Vector2 look;
    public float stamina = 200f;
    public  int health = 100;
    float horizontalInput;
    float verticalInput;

    // States
    public bool isWalking;
    bool runPressed;
    public bool isRunning;
    public bool FlashlightOn;
    public bool FlashlightTaken;
    bool played = false;
    // References
    Character player;
    CharacterController characterController;
    public Camera gameCamera;
    public Transform Front;
    public Transform Cam;
    public GameObject Flashlight;
    [SerializeField] private AudioSource flashsound;
   
    void Start()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the cursor
        Cursor.visible = false;
        player = GetComponent<Character>();
        characterController = GetComponent<CharacterController>();
        //gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameOver.SetActive(false);
        Flashlight.SetActive(false);
        FlashlightOn = false;
        FlashlightTaken = false;
        Time.timeScale = 1f;
        health = PlayerPrefs.GetInt("Phealth");

    }
    void Awake()
    {
       
        //Cam = transform.Find("campiv");
       
    }

    void Update()
    {

        

        //SPRINTING
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        runPressed = Input.GetKey(KeyCode.LeftShift);
      
        //ANIMATION ROTATION CHECK
        float Rotation;

        //HEALTH
        health = health;
        PlayerPrefs.SetInt("Phealth", health);
        if (health >= 80 && health <= 100)
        {
            Status.color = Color.green;
        }
        else if (health >= 60)
        {
            Status.color = Color.white;
        }
        else if (health >= 40)
        {
            Status.color = Color.yellow;
        }
        else if (health >= 20)
        {
            Status.color = orange;

        }
        else if (health >= 1)
        {
            Status.color = Color.red;
        }
        else if (health <= 0)
        {
            Time.timeScale = 0f;
            GameOver.SetActive(true);
            health = 100;
        }
        else
        {
            Status.color = Color.black;
            
        }
     

        //END OF HEALTH
      
            Rotation = Front.eulerAngles.y + Cam.eulerAngles.y;
            
        if(Cam.position.x < 0f)
        {
            Rotation = Front.eulerAngles.y - Cam.eulerAngles.y;
        }

        if (Rotation > 360f)
        {
            Rotation = 0f;
        }
        if (Rotation < 0)
        {
            Rotation += 360;
        }



        //Debug.Log(Rotation);



        animator.SetFloat("Angle", Rotation);


        //idleF
        if(Rotation > 157.5 && Rotation <= 202.5)
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", -0.1f);
        }
        //idleL
        else if (Rotation > 247.5 && Rotation <= 292.5)
        {
            animator.SetFloat("lastmovex", -0.1f);
            animator.SetFloat("lastmovey", 0f);
        }
        //idleB
        else if (Rotation > 337.5 && Rotation <= 360)
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", 0.1f);
        }
        else if (Rotation > 0 && Rotation <= 22.5)
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", 0.1f);
        }//idleR

        else if (Rotation > 67.5 && Rotation <= 112.5)
        {
            animator.SetFloat("lastmovex", 0.1f);
            animator.SetFloat("lastmovey", 0f);
        }
        //idleFL
        else if (Rotation > 202.5 && Rotation <= 247.5)
        {
            animator.SetFloat("lastmovex", -0.1f);
            animator.SetFloat("lastmovey", -0.1f);
        }
        //idleFR
        else if (Rotation > 112.5 && Rotation <= 157.5)
        {
            animator.SetFloat("lastmovex", 0.1f);
            animator.SetFloat("lastmovey", -0.1f);
        }
        //idleBL
        else if (Rotation > 292.5 && Rotation <= 337.5)
        {
            animator.SetFloat("lastmovex", -0.1f);
            animator.SetFloat("lastmovey", 0.1f);
        }
        //idleBR
        else if (Rotation > 22.5 && Rotation <= 67.5)
        {
            animator.SetFloat("lastmovex", 0.1f);
            animator.SetFloat("lastmovey", 0.1f);
        }
        else 
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", 0.1f);
        }



        //MOVEMENT CHECK
        if (Input.GetMouseButtonDown(1))
        {
            player.isAiming = true;
            //tankControls = false;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            player.isAiming = false;
            tankControls = true;
        }

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

            if (tankControls)
            {
                float h = horizontalInput * Time.deltaTime * turnspeed;
                float v = verticalInput * Time.deltaTime * speed;

                

               



                Move(h, v);
            }
            else
            {
                float h = horizontalInput * Time.deltaTime * turnspeed;
                float v = verticalInput * Time.deltaTime * speed;
            }

        }

        bool movingForward = false;
        bool movingBackward = false;

        if (verticalInput > 0)
        {
            if (!movingForward)
            {
                movingForward = true;
            }
        }
        else if (verticalInput < 0)
        {
            if (tankControls)
            {
                movingForward = false;
                movingBackward = true;
            }
            else
            {
                movingForward = true;
            }

        }

        else if (!tankControls && horizontalInput != 0)
          {
            movingForward = true;
          }
        else
        {
            movingForward = false;
        }
        if (movingForward && runPressed)
        {
            if (stamina > 0)
            {
               animator.SetFloat("Speed", 1.5f);
                isRunning = true;
                if(speed < runspeed)
                    speed += 5f * Time.deltaTime;

                stamina -= 10f * Time.deltaTime;
            }
            else
            {
                animator.SetFloat("Speed", 0.8f);
                stamina = 0f;
                if (speed > backspeed)
                {
                    speed -= 5f * Time.deltaTime;
                }
            }
            
        }
        else if (movingBackward)
        {
            animator.SetFloat("Speed", 0.8f);
            speed = backspeed;
        }
        else
        {
            isRunning = false;
            speed = walkspeed;

            if (stamina < 200f)
            {
                stamina += 20f * Time.deltaTime;
            }
        }

        if (FlashlightTaken)
        {
            if (Input.GetKeyDown(KeyCode.F) && !FlashlightOn)
            {
                Flashlight.SetActive(true);
                FlashlightOn = true;
                flashsound.Play();
            }
            else if (Input.GetKeyDown(KeyCode.F) && FlashlightOn)
            {
                Flashlight.SetActive(false);
                FlashlightOn = false;
                flashsound.Play();
            }

        }




    }

    

    void Move(float h, float v)
    {

       

        if (v != 0f || h != 0f)
        {
            animator.SetFloat("Speed", 1);

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }


        


        if (tankControls && !player.isAiming)
        {
           
            Vector3 move = new Vector3(0, 0, v);
            move = transform.TransformDirection(move);
            move.y -= gravity * Time.deltaTime;
            characterController.Move(move);

            Vector3 turn = new Vector3(0, h, 0);

            transform.Rotate(turn);



        }
        else if (player.isAiming)
        {

            look.x = characterController.transform.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * 5f;
            //look.y += Input.GetAxis("Mouse Y") * 0.5f;
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            characterController.transform.localRotation = Quaternion.Euler(0, look.x, 0);
            //transform.localRotation = Quaternion.Euler(-look.y, 0, 0);
            Vector3 strafe = transform.right * x + transform.forward * z;

            characterController.Move(strafe * aimspeed * Time.deltaTime);

        }


    }


}


