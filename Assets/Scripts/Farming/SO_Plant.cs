using Inventory.Model;
using UnityEngine;

[CreateAssetMenu]
public class SO_Plant : ScriptableObject
{
    [field: SerializeField]
    public string plantName { get; set; }

    [field: SerializeField]
    public Sprite[] plantStageSprite { get; set; }

    [field: SerializeField]
    public SO_Consumable crop { get; set; }

    [field: SerializeField]
    public SO_Plant[] companionPlants { get; set; }

    [field: SerializeField]
    public SO_Plant[] antagonistPlants { get; set; }

}
