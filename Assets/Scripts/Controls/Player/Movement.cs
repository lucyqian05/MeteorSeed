using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerInput playerInput;
    private Animator animator;
    private Rigidbody2D rBody;

    private float moveSpeed = 5f;
    private bool playerRunning = true;
    public bool stopPlayerMovement = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();

        playerController.OnRun += Run;
    }

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

    void FixedUpdate()
    {
        if (!stopPlayerMovement)
        {
            EnablePlayerMovement();
            //Debug.Log("Enabled");
        }
        else
        {
            DisablePlayerMovement();
            //Debug.Log("Disabled");
        }
        
    }

    private void DisablePlayerMovement()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector2 move = new Vector2(input.x, input.y);
        moveSpeed = 0;
        rBody.velocity = move * moveSpeed;
    }

    private void EnablePlayerMovement()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector2 move = new Vector2(input.x, input.y);
        rBody.velocity = move * moveSpeed;

        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);

        if (animator.GetFloat("Horizontal") != 0 || animator.GetFloat("Vertical") != 0)
        {
            if (playerRunning)
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

        if (input.x != 0 || input.y != 0)
        {
            Vector2 lastMotionVector;
            lastMotionVector = new Vector2(input.x, input.y).normalized;

            animator.SetFloat("lastHorizontal", input.x);
            animator.SetFloat("lastVertical", input.y);
        }
    }
}
