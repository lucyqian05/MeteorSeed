using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    [SerializeField]
    public SO_Plant plantData;

    public Tilemap farmlandTilemap;

    public Vector3Int plantLocation;

    public RuleTile biyoTile; 

    private Sprite plantSprite;

    private TimeEventManager timeEventManager;

    private void Start()
    {
        timeEventManager = GetComponent<TimeEventManager>();

        timeEventManager.OnDayChanged += CheckWatered;
        timeEventManager.OnDayChanged += Grow;

    }

    private void CheckWatered()
    {
        bool watered = plantData.plantWatered;
        Debug.Log(watered);
        TileBase plantTile = farmlandTilemap.GetTile(plantLocation); 
        if (plantTile = biyoTile)
        {
            plantData.plantWatered = true;
            Debug.Log(watered);
        }
    }

    public void Grow()
    {
        plantData.PlantGrowth();
    }

    private void KillPlant()
    {

    }
}
