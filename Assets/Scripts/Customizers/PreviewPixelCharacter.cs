using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPixelCharacter : MonoBehaviour
{
    Animator animator;

    //Helps set the direction you want the preview to go in 
    public float horizontalDirection;
    public float verticalDirection;

    public void ToggleWalk()
    {
        if (animator.GetBool("isWalking") == true)
        {
            animator.SetBool("isWalking", false);
        } else
        {
            animator.SetBool("isWalking", true);
        }
    }

    //sets the animator to one direction for the preview 
    public void SetDirection()
    {
        animator.SetFloat("Vertical", verticalDirection);
        animator.SetFloat("lastVertical", verticalDirection);

        animator.SetFloat("Horizontal", horizontalDirection);
        animator.SetFloat("lastHorizontal", horizontalDirection);

    }

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        SetDirection(); 
    }
}
