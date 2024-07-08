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
    private Tilemap plantTilemap;

    [SerializeField]
    private Tile agniTileTag;

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
        if (plant != null)
        {
            if (isInRange == true)
            {
                if (plant.readyForHarvest)
                {
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

                    if (plant.plantData.daysToRegrow == 0)
                    {
                        //To remove the plant from the crop manager 
                        Vector3Int plantLocation = plant.plantLocation;
                        cropManager.cropManager.Remove(plantLocation);

                        //to set the plant tile map so that new plants can be put on
                        Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);
                        plantTilemap.SetTile(plantLocation, agniTileTag);
                        plantTilemap.SetTileFlags(plantLocation, TileFlags.None);
                        plantTilemap.SetColor(plantLocation, clearTile);
                    }
                    //Removes the game object if it does not regrow. If it does, it resets the growthCounter 
                    plant.Harvest();
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
