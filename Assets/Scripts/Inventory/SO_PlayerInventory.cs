using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Player Inventory")]

public class SO_PlayerInventory : ScriptableObject
{

    public List<SO_ItemData> items = new List<SO_ItemData>();

}
