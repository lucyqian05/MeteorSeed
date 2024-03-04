using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryControllerUI : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private InventoryUI inventoryUI;

        [SerializeField]
        private SO_PlayerInventory inventoryData;
#pragma warning restore 0649

        public List<InventoryItem> initialItems = new List<InventoryItem>();
        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (var item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.Image, item.Value.quantity);
            }
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
            inventoryUI.OnSwapItems += HandleSwapItems;
            inventoryUI.OnStartDragging += HandleDragging;
            //inventoryUI.OnItemActionRequested += HandleItemActionRequest;
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
            inventoryData.SwapItems(itemIndex_1, itemIndex_2);
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;
            inventoryUI.CreateDraggedItem(inventoryItem.item.Image, inventoryItem.quantity);
        }

        private void HandleItemActionRequest(int itemIndex)
        {

        }
    }
}