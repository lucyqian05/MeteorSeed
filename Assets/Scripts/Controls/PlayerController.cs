using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerControls playerControls; 


    private Animator animator;
    private Rigidbody2D rBody;


    [SerializeField]
    private int currentMagic = 0; 
    private float moveSpeed = 5f;
    private bool playerRunning = true;



    private void Start()
    {
        animator = GetComponent<Animator>(); 
        rBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }


    private void OnEnable()
    {
        playerControls.Enable();

        playerControls.Player.Run.performed += Run;
        playerControls.Player.Magic.performed += Magic;
        playerControls.Player.ScrollMagic.performed += ScrollMagic;

    }

    private void OnDisable()
    {
        playerControls.Disable();

        playerControls.Player.Run.performed -= Run;
        playerControls.Player.Magic.performed -= Magic;
        playerControls.Player.ScrollMagic.performed -= ScrollMagic;

    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // ACTIONS: TOGGLE RUN, MAGIC, ATTACK                                                       ///////
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This area of code is where I house all the actions the player can do. I could have separated it
    /// all out into different components, but I didn't want so many different components grabbing at
    /// the same component in ways I couldn't see on the same screen. Maybe this is a bad idea but until
    /// it becomes unbearable I'm doing it like this. 
    /// </summary>

    private void Run(InputAction.CallbackContext context)
    {
        if (playerRunning)
        {
            playerRunning = false; 
        }
        else
        {
            playerRunning = true; 
        }
    }

    private void ScrollMagic(InputAction.CallbackContext context)
    {

        if(currentMagic < 3)
        {
            currentMagic++;
        }
        else
        {
            currentMagic = 0;
        }
    }

    private void Magic(InputAction.CallbackContext context)
    {
        switch(currentMagic)
        {
            case 0:
                Fire();
                break;

            case 1:
                Water();
                break;

            case 2:
                Earth();
                break;

            case 3:
                Air();
                break;

        }

    }




    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // MAGIC                                                                                    ///////
    ///////////////////////////////////////////////////////////////////////////////////////////////////

    private void Fire()
    {

        animator.SetTrigger("Fire");
        Debug.Log("Fire!"); 

    }

    private void Earth()
    {

        animator.SetTrigger("Earth");
        Debug.Log("Earth!");

    }

    private void Water()
    {

        animator.SetTrigger("Water");
        Debug.Log("Water!");

    }


    private void Air()
    {

        animator.SetTrigger("Air");
        Debug.Log("Air!");

    }






    void FixedUpdate()
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // MOVEMENT                                                                                 ///////
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector2 move = new Vector2(input.x, input.y);
        rBody.velocity = move * moveSpeed;


        //Updates the animation based on the player input
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);


        //Updates the animators based on the player input. This also controls the player speed 
        //Because I'm lazy to figure out another way. 
        if (animator.GetFloat("Horizontal") !=0 || animator.GetFloat("Vertical") !=0)
        {
            if (playerRunning == true)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
                moveSpeed = 5f;

            }
            else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                moveSpeed = 2f;
            }

        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }



        //Sets the idle to the last idle direction the player was facing
        if(input.x != 0 || input.y != 0)
        {
            Vector2 lastMotionVector;
            lastMotionVector = new Vector2(input.x, input.y).normalized;

            animator.SetFloat("lastHorizontal", input.x);
            animator.SetFloat("lastVertical", input.y);
        }





    }







    /// <summary>
    /// CODE GRAVEYARD: Another way to use the Input Controls. 
    /// I couldn't find a concrete way to get a single value returned on button pressed. Even Action.Triggered returns between one to two responses
    /// So this code will be on the back burner unless I decide to compeletely change things. Again. 
    /// </summary>
    ///
    /// 
    /// 
    // private InputAction runAction;
    //runAction = playerInput.actions["Run"];
    //if (runAction.triggered)
    //{
    //    Debug.Log(runAction.ReadValue<float>());

    //    if(playerRunning)
    //    {
    //        playerRunning = false; 
    //    }
    //    else
    //    {
    //        playerRunning = true; 
    //    }

    //}







}
