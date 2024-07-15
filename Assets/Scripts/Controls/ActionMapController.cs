using UnityEngine.InputSystem; 
using UnityEngine;

public class ActionMapController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerController playerController;
    private SeedModeController seedModeController;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<PlayerController>();
        seedModeController = GetComponent<SeedModeController>();
    }

    public void EnablePlayerController()
    {
        playerInput.actions.FindActionMap("Player").Enable();
        playerController.OnEnable();

        playerInput.actions.FindActionMap("Seed Mode").Disable();
        seedModeController.OnDisable();

    }

    public void EnableSeedModeController()
    {
        playerInput.actions.FindActionMap("Player").Disable();
        playerController.OnDisable();

        playerInput.actions.FindActionMap("Seed Mode").Enable();
        seedModeController.OnEnable();
    }



}
