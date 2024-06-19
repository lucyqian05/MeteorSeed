using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class SO_Seed : SO_ItemData, IPlantable, IDestroyableItem
    {
        [field: SerializeField]
        public SO_Plant Plant { get; set; }

        [field: SerializeField]
        public string Season { get; set; }
    }

    public interface IPlantable
    {

    }
}
