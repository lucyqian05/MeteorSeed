using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Consumable Item")]

public class SO_Consumables : ScriptableObject
{
    [Header("Item Name")]
    public string itemType = "Consumable";
    public string itemName;

    [Header("Item Image")]
    public Sprite itemImage;

    [Header("Currency Information")]
    public int itemPrice;
    public int itemSell;

    [Header("Item Stats")]
    public int hpStat;
    public int magicStat;
    public int energyStat;

    [TextArea]
    public string itemDescription;

}
