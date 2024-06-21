using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{

    private PlayerControls playerControls; 

    public event Action<InputAction.CallbackContext> OnEat, OnInteract, 
        OnMagic, OnScrollMagic, OnRun;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    public void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Run.performed += Run;
        playerControls.Player.Magic.performed += Magic;
        playerControls.Player.ScrollMagic.performed += ScrollMagic;
        playerControls.Player.Interact.performed += Interact;
        playerControls.Player.Eat.performed += Eat;
    }

    public void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.Run.performed -= Run;
        playerControls.Player.Magic.performed -= Magic;
        playerControls.Player.ScrollMagic.performed -= ScrollMagic;
        playerControls.Player.Interact.performed -= Interact;
        playerControls.Player.Eat.performed -= Eat;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke(context);
    }

    private void Eat(InputAction.CallbackContext context)
    {
        OnEat?.Invoke(context);
    }

    private void Run(InputAction.CallbackContext context)
    {
        OnRun?.Invoke(context);
    }

    private void Magic(InputAction.CallbackContext context)
    {
        OnMagic?.Invoke(context);
    }

    private void ScrollMagic(InputAction.CallbackContext context)
    {
        OnScrollMagic?.Invoke(context);
    }
}
