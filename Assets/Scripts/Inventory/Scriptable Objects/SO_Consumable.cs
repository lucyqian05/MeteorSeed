using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class SO_Consumable : SO_ItemData, IDestroyableItem, IItemAction
    {
        [SerializeField]
        private List<ModifierData> modifiersData = new List<ModifierData>();
        public string ActionName => "Consume";

        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject player)
        {
            foreach (ModifierData data in modifiersData)
            {
                data.statModifier.AffectPlayer(player, data.value);
            }
            return true;
        }
    }

    public interface IDestroyableItem
    {

    }

    public interface IItemAction
    {
        public string ActionName { get; }
        public AudioClip actionSFX { get; }
        bool PerformAction(GameObject player);
    }

    [Serializable] 
    public class ModifierData
    {
        public SO_PlayerStatModifier statModifier;
        public float value;
    }
}

