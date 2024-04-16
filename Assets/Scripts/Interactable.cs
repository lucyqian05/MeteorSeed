using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    private UnityEngine.InputSystem.PlayerInput playerInput;
    private InputAction controllerInputAction; 
    

    private void Start ()
    {
        playerInput = GetComponent<PlayerInput>();
        controllerInputAction = playerInput.actions["Interact"];
    }

    void Update()
    {
        if(isInRange)
        {
            if(controllerInputAction.triggered)
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
