using Inventory.Model;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class HarvestSystem : MonoBehaviour
{

    [SerializeField]
    private SO_PlayerInventory inventoryData;

    [SerializeField]
    private CropsManager cropManager;

    [SerializeField]
    private PlantTilemapManager plantTilemapManager;

    [SerializeField]
    private Tile noPlantPlaceholder;

    private PlayerController playerController;
    private PlayerInput playerInput;
    //private InputAction controllerInputAction;

    public Item item;
    private Plant plant; 
    private bool isInRange = false;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();
        //controllerInputAction = playerInput.actions["MousePosition"];

        plant = GetComponent<Plant>();

        playerController.OnInteract += Harvest;
    }

    private void AriaItem()
    {
        if (item != null)
        {

        }
    }

    private void Harvest(InputAction.CallbackContext context)
    {
        if (plant != null && isInRange == true)
        {
            if (plant.readyForHarvest)
            {
                //Handles adding the crop to the inventory
                SO_ItemData crop = plant.GetItem();
                int quantity = plant.GetQuantity();
                int remainder = inventoryData.AddItem(crop, quantity);

                if (remainder > 0)
                {
                    for (int i = 0; i < remainder; i++)
                    {
                        Vector3Int transform = plant.plantLocation;
                        Item cropItem = Instantiate(item, transform, Quaternion.identity);
                        cropItem.InventoryItem = crop;
                        item.Quantity = 1;
                    }
                }
                
                //handles what happens to the plant if it doesn't regrow. It shouldn't be handled here. It should be decided inside the Plant
                //Logic for destroying the crop should rest in the crop manager so that it can be completely removed
                //Logic for whether plant regrows or not should be handled in Plant 
                if (plant.plantData.daysToRegrow == 0)
                {
                    Vector3Int plantLocation = plant.plantLocation;

                    cropManager.RemoveCrop(plantLocation);
                    plantTilemapManager.SetNoPlantPlaceholder(plantLocation);
                }
                plant.Harvest();
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
