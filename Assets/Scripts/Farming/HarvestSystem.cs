using Inventory.Model;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class HarvestSystem : MonoBehaviour
{

    [SerializeField]
    private SO_PlayerInventory inventoryData;

    private PlayerController playerController;
    private Magic magic;
    private PlayerInput playerInput;
    private InputAction controllerInputAction;

    public Item item;
    private Plant plant; 
    private bool isInRange = false;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        magic = GetComponent<Magic>();
        playerInput = GetComponent<PlayerInput>();
        controllerInputAction = playerInput.actions["MousePosition"];

        plant = GetComponent<Plant>();

        playerController.OnInteract += Harvest;
        magic.OnAria += AriaItem;
    }

    private void AriaItem()
    {
        if (item != null)
        {

        }
    }

    private void Harvest(InputAction.CallbackContext context)
    {
        if (plant != null)
        {
            if (isInRange == true)
            {
                if (plant.readyForHarvest)
                {

                    SO_ItemData crop = plant.GetItem();
                    int quantity = plant.GetQuantity();
                    int remainder = inventoryData.AddItem(crop, quantity);
                    plant.Harvest();
                    if(remainder == 0)
                    {
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < remainder; i++)
                        {
                            Vector3Int transform = plant.plantLocation;
                            Item cropItem = Instantiate(item, transform, Quaternion.identity);
                        }
                    }
                }              
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plant = collision.GetComponent<Plant>();
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
