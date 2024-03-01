using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerUI : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField]
    private InventoryUI inventoryUI;

    [SerializeField]
    private SO_PlayerInventory inventoryData;
#pragma warning restore 0649

    
    private void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
    }

    private void Update()
    {
        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key,
                item.Value.item.Image,
                item.Value.quantity);
        }
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.PocketSize);
        //this.inventoryUI.OnItemSelected += HandleItemSelected;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    //private void HandleItemSelected(int itemIndex)
    //{
    //    InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
    //    if (inventoryItem.IsEmpty)
    //        return;
    //    SO_ItemData item = inventoryItem.item;

        
    //}

    private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
    {
        
    }

    private void HandleDragging(int itemIndex)
    {

    }

    private void HandleItemActionRequest(int itemIndex)
    {

    }
}
