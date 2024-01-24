using UnityEngine;

public class CutsceneAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void idleLeftAnimation()
    {

        animator.SetBool("isWalking", false);
        animator.SetFloat("lastHorizontal", -1);
        animator.SetFloat("lastVertical", 0);

    }

    public void idleRightAnimation()
    {

        animator.SetBool("isWalking", false);
        animator.SetFloat("lastHorizontal", 1);
        animator.SetFloat("lastVertical", 0);

    }


    public void walkUpAnimation()
    {

        animator.SetBool("isWalking", true);
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 1);

    }

    public void walkDownAnimation()
    {

        animator.SetBool("isWalking", true);
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);

    }

    public void walkLeftAnimation()
    {

        animator.SetBool("isWalking", true);
        animator.SetFloat("Horizontal", -1);
        animator.SetFloat("Vertical", 0);

    }

    public void walkRightAnimation()
    {

        animator.SetBool("isWalking", true);
        animator.SetFloat("Horizontal", 1);
        animator.SetFloat("Vertical", 0);

    }

}
