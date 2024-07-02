using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using static DateAndTime.TimeManager;

public class Plant : MonoBehaviour
{
    public SO_Plant plantData;

    public Sprite deadPlant;

    public Tilemap farmlandTilemap;

    public Vector3Int plantLocation;

    public RuleTile biyoTile;

    public Item item; 

    private SpriteRenderer plantSpriteRenderer;

    private TimeEventManager timeEventManager;

    private void Start()
    {
        timeEventManager = GetComponent<TimeEventManager>();
        plantSpriteRenderer = GetComponent<SpriteRenderer>();

        timeEventManager.OnDayChanged += Grow;

        SetPlant();
    }

    private void CheckWatered()
    {
        TileBase plantTile = farmlandTilemap.GetTile(plantLocation);
        if (plantTile == biyoTile)
        {
            plantData.plantWatered = true;
        }
    }
    private void CheckSeason(Season currentSeason)
    {

    }

    public void Grow()
    {
        CheckWatered();

        if (!plantData.plantWatered)
        {
            plantData.daysUnwatered++;
            if(plantData.daysUnwatered == plantData.unwateredPlantDeath)
            {
                KillPlant();
            }
            return;
        }

        plantData.growthCounter++;

        Sprite newPlantSprite = plantData.GetPlantSprite();
        plantSpriteRenderer.sprite = newPlantSprite;

        plantData.plantWatered = false;
    }
    
    public void HarvestCrop()
    {
        if (plantData.growthCounter > plantData.daysToGrow)
        {

        }
    }

    private void KillPlant()
    {
        timeEventManager.OnDayChanged -= Grow;
        plantSpriteRenderer.sprite = deadPlant; 
    }

    private void SetPlant()
    {
        Sprite newPlantSprite = plantData.plantStageSprite[0];
        plantSpriteRenderer.sprite = newPlantSprite;

        plantData.growthCounter = 1;
        plantData.daysUnwatered = 0;
        plantData.plantWatered = false;

        plantData.CalculatePlantStages();
}

    public void DestroyPlant()
    {
        Destroy(gameObject);
    }
}
