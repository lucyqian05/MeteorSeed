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

<<<<<<< HEAD
        public event Action<int> OnItemActionRequested, OnDropItems,
=======
        public event Action<int> //OnDescriptionRequested,
<<<<<<< HEAD
            //OnItemActionRequested,
=======
            OnItemActionRequested,
>>>>>>> parent of b6291be (Inventory Update)
>>>>>>> 66ad28c8f441243dc44dd1b9fceec1b229e8c0f8
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
<<<<<<< HEAD
                uiItem.OnRightMouseBtnClick += HandleShowItemActions;
=======
                uiItem.OnConsume += HandleShowItemActions;
>>>>>>> parent of b6291be (Inventory Update)
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