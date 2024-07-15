using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SeedModeController : MonoBehaviour
{
    //Known issue: For some reason, the RightClick is still considered as performed when seedmode control shouldn't be enabled 

    private PlayerControls seedModeControls;

    public event Action<InputAction.CallbackContext> OnRightClick;

    private void Awake()
    {
        seedModeControls = new PlayerControls();
        
    }

    public void OnEnable()
    {
        seedModeControls.Enable();
        seedModeControls.SeedMode.RightClick.performed += OnRightPointer;
    }

    public void OnDisable()
    {
        seedModeControls.SeedMode.RightClick.performed -= OnRightPointer;
        seedModeControls.Disable();      
    }

    private void OnRightPointer(InputAction.CallbackContext obj)
    {
        OnRightClick?.Invoke(obj);
    }


}
