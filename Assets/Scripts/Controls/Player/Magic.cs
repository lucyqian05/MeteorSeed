using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magic : MonoBehaviour
{
    [SerializeField]
    private int currentMagic = 0;

    private Animator animator;
    private PlayerController playerController;
    private Movement movement;
    public float targetTime = 0.0f;


    public event Action OnAgni, OnErde, OnBiyo, OnAria;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        movement = GetComponent<Movement>();

        playerController.OnMagic += Magics;
        playerController.OnScrollMagic += ScrollMagic;
    }
    private void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            movement.stopPlayerMovement = false;
        }
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
        movement.stopPlayerMovement = true;
        if (targetTime <= 0)
        {
            SetTimer();

            switch (currentMagic)
            {
                case 0:
                    animator.SetTrigger("Agni");
                    OnAgni?.Invoke();

                    break;
                case 1:
                    animator.SetTrigger("Erde");
                    OnErde?.Invoke();
                    break;

                case 2:
                    animator.SetTrigger("Biyo");
                    OnBiyo?.Invoke();
                    break;

                case 3:
                    animator.SetTrigger("Aria");
                    OnAria?.Invoke();
                    break;
            }
        }     
    }

    private void SetTimer()
    {
        targetTime = 1.0f;
    }
}
