using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(fileName = "New Player Inventory", menuName = "Player Inventory")]

    public class SO_PlayerInventory : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItem> inventoryItems;

        [field: SerializeField]
        public int PocketSize { get; private set; } = 10;

        [field: SerializeField]
        public Item item;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < PocketSize; i++)
            {
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        public int AddItem(SO_ItemData item, int quantity)
        {
            if(item.IsStackable == false)
            {
#pragma warning disable CS0162 // Unreachable code detected
                for (int i = 0; i < inventoryItems.Count; i++)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    while(quantity > 0  && IsInventoryFull() == false)
                    {
                        quantity -= AddItemToFirstFreeSlot(item, 1);
                    }
                    InformAboutChange();
                    return quantity;
                }
            }
            quantity = AddStackableItem(item, quantity);
            InformAboutChange();
            return quantity;
        }

        private int AddItemToFirstFreeSlot(SO_ItemData item, int quantity)
        {
            InventoryItem newItem = new InventoryItem
            {
                item = item,
                quantity = quantity
            };

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = newItem;
                    return quantity; 
                }
            }
            return 0;
        }

        private bool IsInventoryFull()
            => inventoryItems.Where(item => item.IsEmpty).Any() == false; 

        private int AddStackableItem(SO_ItemData item, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                if(inventoryItems[i].item.ID == item.ID)
                {
                    int amountPossibleToTake =
                        inventoryItems[i].item.MaxStackSize - inventoryItems[i].quantity;

                    if (quantity > amountPossibleToTake)
                    {
                        inventoryItems[i] = inventoryItems[i]
                            .ChangeQuantity(inventoryItems[i].item.MaxStackSize);
                        quantity -= amountPossibleToTake;
                    }
                    else
                    {
                        inventoryItems[i] = inventoryItems[i]
                            .ChangeQuantity(inventoryItems[i].quantity + quantity);
                        InformAboutChange();
                        return 0;
                    }
                }
            }
            while(quantity > 0 && IsInventoryFull() == false)
            {
                int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
                quantity -= newQuantity;
                AddItemToFirstFreeSlot(item, newQuantity);
            }
            return quantity;
        }

        public void RemoveItem(int itemIndex, int amount)
        {
            if(inventoryItems.Count > itemIndex)
            {
                if (inventoryItems[itemIndex].IsEmpty)
                    return;
                int remainder = inventoryItems[itemIndex].quantity - amount;
                if (remainder <= 0)
                    inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
                else
                    inventoryItems[itemIndex] = inventoryItems[itemIndex]
                        .ChangeQuantity(remainder);
                InformAboutChange(); 
            }
        }

        public void DropItem(int itemIndex)
        {
            if (inventoryItems.Count > itemIndex)
            {
                if (inventoryItems[itemIndex].IsEmpty)
                    return;
                GameObject player;
                player = GameObject.FindGameObjectWithTag("Player");
                Vector3 transform;
                transform = player.transform.position;
                Item itemDrop = Instantiate(item, transform, Quaternion.identity);
                Item itemInfo = itemDrop.GetComponent<Item>();
                itemInfo.name = inventoryItems[itemIndex].item.name;
                itemInfo.InventoryItem = inventoryItems[itemIndex].item;
                itemInfo.Quantity = inventoryItems[itemIndex].quantity;
                inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
                InformAboutChange();
            }
        }

        public void AddItem(InventoryItem item)
        {
            AddItem(item.item, item.quantity);
        }

        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue =
                new Dictionary<int, InventoryItem>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem item1 = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item1;
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }
    }

    [Serializable]
    public struct InventoryItem
    {
        public int quantity;
        public SO_ItemData item;
        public bool IsEmpty => item == null;

        public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = newQuantity,
            };
        }

        public static InventoryItem GetEmptyItem()
            => new InventoryItem
            {
                item = null,
                quantity = 0,
            };
    }

}

