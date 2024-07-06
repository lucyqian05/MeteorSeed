using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryUI : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private InventoryItemUI itemPrefab;

        [SerializeField]
        private RectTransform contentPanel;

        [SerializeField]
        private MouseFollower mouseFollower;

#pragma warning restore 0649

        List<InventoryItemUI> listOfUIItems = new List<InventoryItemUI>();

        private int currentlyDraggedItemIndex = -1;
        private bool swapItem = false; 

        public event Action<int> OnItemActionRequested, OnDropItems,
            OnStartDragging;

        public event Action<int, int> OnSwapItems;


        private void Awake()
        {
            mouseFollower.Toggle(false);
        }

        public void InitializeInventoryUI(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                InventoryItemUI uiItem =
                    Instantiate(itemPrefab);
                uiItem.transform.SetParent(contentPanel);
                uiItem.transform.localScale = new Vector3(1, 1, 1);
                listOfUIItems.Add(uiItem);

                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnItemActionRequested += HandleShowItemActions;
            }
        }

        public void ResetAllItems()
        {
            foreach (var item in listOfUIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }

        public void UpdateData(int itemIndex,
            Sprite itemSprite, int itemQuantity)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemSprite, itemQuantity);
            }
        }

        private void HandleItemSelection(InventoryItemUI inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            DeselectAllItems();
            listOfUIItems[index].Selection();
        }

        private void HandleBeginDrag(InventoryItemUI inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            currentlyDraggedItemIndex = index;
            HandleItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite, quantity);
        }

        private void HandleSwap(InventoryItemUI inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
            swapItem = true;
        }

        private void HandleEndDrag(InventoryItemUI inventoryItemUI)
        {
            if (swapItem == false)
            {
                OnDropItems?.Invoke(currentlyDraggedItemIndex);
            }
            swapItem = false;
            ResetDraggedItem();
        }

        private void HandleShowItemActions(InventoryItemUI inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnItemActionRequested?.Invoke(index);
        }

        private void ResetDraggedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        private void ResetSelection()
        {
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (InventoryItemUI item in listOfUIItems)
            {
                item.Deselect();
            }
        }
    }
}