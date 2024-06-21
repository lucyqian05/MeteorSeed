using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrushers;

public class RegisterMyControls : MonoBehaviour
{
    protected static bool isRegistered = false;
    private bool didIRegister = false;
    private PlayerControls controls;
    void Awake()
    {
        controls = new PlayerControls();
    }
    void OnEnable()
    {
        if (!isRegistered)
        {
            isRegistered = true;
            didIRegister = true;
            controls.Enable();
            //InputDeviceManager.RegisterInputAction("Back", controls.Player.Back);
            InputDeviceManager.RegisterInputAction("Interact", controls.Player.Interact);
        }
    }
    void OnDisable()
    {
        if (didIRegister)
        {
            isRegistered = false;
            didIRegister = false;
            controls.Disable();
            //InputDeviceManager.UnregisterInputAction("Back");
            InputDeviceManager.UnregisterInputAction("Interact");
        }
    }

}
