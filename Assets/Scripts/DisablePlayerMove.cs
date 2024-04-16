using UnityEngine;
using UnityEngine.InputSystem;

public class DisablePlayerMove : MonoBehaviour
{
    public GameObject player; 
    private UnityEngine.InputSystem.PlayerInput playerInput;

    void Start()
    {

        playerInput = player.GetComponent<PlayerInput>();

    }

    public void DisableMove()
    {

        playerInput.enabled = false;

    }

    public void EnableMove()
    {

        playerInput.enabled = true;

    }


}
