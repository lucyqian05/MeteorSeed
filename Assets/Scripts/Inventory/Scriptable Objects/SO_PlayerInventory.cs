using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Player Inventory")]

public class SO_PlayerInventory : ScriptableObject
{
    public int maxItems = 10; 
    public List<SO_ItemData> items = new List<SO_ItemData>();
    public bool AddItem(SO_ItemData itemToAdd)
    {
        // Finds an empty slot if there is one
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
        }

        // Adds a new item if the inventory has space

        if (items.Count <maxItems)
        {
            items.Add(itemToAdd);
            return true;
        }

        Debug.Log("No space in the inventory");
        return false;
    }


}
