using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMirrored : MonoBehaviour
{
    public int ItemCode = 0;
    public bool usedItem;
    public bool tankControls = true;
    public Animator animator;

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
    public float stamina = 100f;

    float horizontalInput;
    float verticalInput;

    // States
    public bool isWalking;
    bool runPressed;
    public bool isRunning;
    public bool FlashlightOn;
    public bool FlashlightTaken;

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
        Flashlight.SetActive(false);
        FlashlightOn = false;
        FlashlightTaken = false;


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




        Rotation = Front.eulerAngles.y + Cam.eulerAngles.y;

        if (Cam.position.x < 0f)
        {
            Rotation = Front.eulerAngles.y - Cam.eulerAngles.y;
        }

        if (Rotation < 360f)
        {
            Rotation = 0f;
        }
        if (Rotation > -20f && Rotation <= -120f)
        {
            Rotation = 300f;
        }
        else if (Rotation > -120f)
        {
            Rotation = 180f;
        }


        Debug.Log(Rotation);



        animator.SetFloat("Angle", Rotation);



        if (Rotation > 135 && Rotation <= 225)
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", -0.1f);
        }
        else if (Rotation > 225 && Rotation <= 315)
        {
            animator.SetFloat("lastmovex", -0.1f);
            animator.SetFloat("lastmovey", 0f);
        }
        else if (Rotation > 315 && Rotation <= 360)
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", 0.1f);
        }
        else if (Rotation > 0 && Rotation <= 45)
        {
            animator.SetFloat("lastmovex", 0f);
            animator.SetFloat("lastmovey", 0.1f);
        }
        else if (Rotation > 45 && Rotation <= 135)
        {
            animator.SetFloat("lastmovex", 0.1f);
            animator.SetFloat("lastmovey", 0f);

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
                float h = -horizontalInput * Time.deltaTime * turnspeed;
                float v = -verticalInput * Time.deltaTime * speed;







                Move(h, v);
            }
            else
            {
                float h = -horizontalInput * Time.deltaTime * turnspeed;
                float v = -verticalInput * Time.deltaTime * speed;
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
                if (speed < runspeed)
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

            if (stamina < 100)
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
