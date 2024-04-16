using UnityEngine;
using UnityEngine.InputSystem;

public class Magic : MonoBehaviour
{
    [SerializeField]
    private int currentMagic = 0;

    private Animator animator;
    private PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        playerController.OnMagic += Magics;
        playerController.OnScrollMagic += ScrollMagic;
    }

    private void ScrollMagic(InputAction.CallbackContext context)
    {
        if (currentMagic < 3)
        {
            currentMagic++;
        }
        else
        {
            currentMagic = 0;
        }
    }

    private void Magics(InputAction.CallbackContext context)
    {
        switch (currentMagic)
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

}
