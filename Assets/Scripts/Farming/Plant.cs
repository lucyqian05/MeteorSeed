using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    [SerializeField]
    public SO_Plant plantData;

    [SerializeField]
    public Sprite deadPlant;

    public Tilemap farmlandTilemap;

    public Vector3Int plantLocation;

    public RuleTile biyoTile; 

    private SpriteRenderer plantSpriteRenderer;

    private TimeEventManager timeEventManager;

    private void Start()
    {
        timeEventManager = GetComponent<TimeEventManager>();
        plantSpriteRenderer = GetComponent<SpriteRenderer>();

        timeEventManager.OnDayChanged += CheckWatered;
        timeEventManager.OnDayChanged += Grow;

        SetPlantSprite();
    }

    private void CheckWatered()
    {
        TileBase plantTile = farmlandTilemap.GetTile(plantLocation);
        if (plantTile == biyoTile)
        {
            plantData.plantWatered = true;
        }
    }

    public void Grow()
    {
        if (!plantData.plantWatered)
        {
            plantData.daysUnwatered++;
            if (plantData.daysUnwatered == plantData.unwateredPlantDeath)
            {
                KillPlant();
            }
        }

        plantData.growthCounter++;
        SetPlantSprite();
        plantData.plantWatered = false;
    }

    private void KillPlant()
    {
        timeEventManager.OnDayChanged -= CheckWatered;
        timeEventManager.OnDayChanged -= Grow;
        plantSpriteRenderer.sprite = deadPlant; 
    }

    private void SetPlantSprite()
    {
        Sprite newPlantSprite = plantData.GetPlantSprite();
        plantSpriteRenderer.sprite = newPlantSprite; 
    }

    public void DestroyPlant()
    {
        Destroy(gameObject);
    }
}
