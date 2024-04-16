using Inventory.Model;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private SO_PlayerInventory inventoryData;
    private PlayerController playerController;

    private Item item;
    private bool isInRange = false;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.OnInteract += PickUp; 
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
