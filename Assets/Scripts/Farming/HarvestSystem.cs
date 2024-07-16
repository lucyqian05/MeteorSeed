using Inventory.Model;
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

    public Item item;
    private Plant plant; 
    private bool isInRange;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();

        playerController.OnInteract += Harvest;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crop"))
        {
            isInRange = true;
            plant = collision.GetComponent<Plant>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crop"))
        {
            isInRange = false;
        }          
    }

    private void Harvest(InputAction.CallbackContext context)
    {
        if (plant != null && isInRange == true)
        {
            bool harvestTime = plant.readyForHarvest;

            if (harvestTime)
            {
                //adds item to inventory and handles remainder if inventory is full 
                SO_ItemData crop = plant.GetRatedCrop();
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

                //handles what happens to the plant after the item is added to inventory
                bool doesRegrow = plant.plantData.GetIfPlantRegrows();
                if (!doesRegrow)
                {
                    Vector3Int plantLocation = plant.plantLocation;
                    plantTilemapManager.SetNoPlantPlaceholder(plantLocation);
                    cropManager.RemoveCrop(plantLocation);
                }
                plant.Harvest();
            }
        }
    }
}
