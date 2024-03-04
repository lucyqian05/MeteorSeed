using UnityEngine;

namespace Inventory.Model
{
    public abstract class SO_ItemData : ScriptableObject
    {
        public int ID => GetInstanceID();

        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        public bool IsStackable { get; set; }

        [field: SerializeField]
        public int MaxStackSize { get; set; } = 1;

        [field: SerializeField]
        public Sprite Image { get; set; }

        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }


        //int itemPrice;
        //int itemSell;

        //int hpStat;
        //int magicStat;
        //int energyStat;

        //string cropRating;

        //string keyItemType;

        //string plantingSeason;
        //string plantGrowTime;
        //string seedRating;
        //string siblingCrop1 = "NONE";
        //string siblingCrop2 = "NONE";
        //string siblingCrop3 = "NONE";
        //string siblingCrop4 = "NONE";


        //bool showConsumable = false;
        //bool showCrop = false;
        //bool showKey = false;
        //bool showResource = false;
        //bool showSeed = false;
    }
}

