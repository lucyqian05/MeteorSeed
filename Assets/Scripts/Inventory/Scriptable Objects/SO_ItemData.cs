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

    }
}

