using Inventory.Model;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private SO_PlayerInventory inventoryData;

    private PlayerController playerController;
    private Magic magic;
    private PlayerInput playerInput;
    private InputAction controllerInputAction;

    private Item item;
    private bool isInRange = false;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        magic = GetComponent<Magic>();
        playerInput = GetComponent<PlayerInput>();
        controllerInputAction = playerInput.actions["MousePosition"];

        playerController.OnInteract += PickUp;
        magic.OnAria += AriaItem;
    }

    private void AriaItem()
    {
        if (item != null)
        {
            
        }
    }

    private void PickUp(InputAction.CallbackContext context)
    {
        if (item != null)
        {
            if (isInRange == true)
            {
                int remainder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
                if (remainder == 0)
                    item.DestroyItem();
                else
                    item.Quantity = remainder;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<Item>();
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
