using Inventory.Model;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using static DateAndTime.TimeManager;

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

    private int growthCounter;
    private int reproduceCounter;

    public bool plantWatered = false;
    public int daysUnwatered;
    private const int unwateredPlantDeath = 3;

    public bool readyForHarvest = false;

    public Action<SO_ItemData> CropProduced;

    private void Start()
    {
        timeEventManager = GetComponent<TimeEventManager>();
        plantSpriteRenderer = GetComponent<SpriteRenderer>();

        timeEventManager.OnDayChanged += Grow;

        SetPlant();
    }

    public void Harvest()
    {
        readyForHarvest = false;
        growthCounter = plantData.GetStageTwoInt();
        Sprite newPlantSprite = plantData.GetPlantSprite(growthCounter);
        plantSpriteRenderer.sprite = newPlantSprite;
    }

    public SO_ItemData GetItem()
    {
        SO_ItemData item = plantData.crop;
        return item;
    }

    public int GetQuantity()
    {
        return plantData.numberOfCrops;
    }

    private void CheckWatered()
    {
        TileBase plantTile = farmlandTilemap.GetTile(plantLocation);
        if (plantTile == biyoTile)
        {
            plantWatered = true;
        }
    }

    private void CheckSeason()
    {
        string plantingSeason = plantData.GetSeasonString();
        string currentSeason = timeEventManager.currentSeason;

        if (plantingSeason != currentSeason)
        {
            KillPlant();
        }
        
    }
    public void Grow()
    {
        CheckWatered();
        CheckSeason();

        if (!plantWatered)
        {
            daysUnwatered++;
            if (daysUnwatered >= unwateredPlantDeath)
            {
                KillPlant();
                return;
            }
            return;
        }
        else if(growthCounter < plantData.daysToGrow)
        {
            growthCounter++;
            Sprite newPlantSprite = plantData.GetPlantSprite(growthCounter);
            plantSpriteRenderer.sprite = newPlantSprite;
            plantWatered = false;
        }
        
        if (growthCounter >= plantData.daysToGrow)
        {
            readyForHarvest = true;
            CropProduced?.Invoke(plantData.crop);
        }
    }

    private void KillPlant()
    {
        timeEventManager.OnDayChanged -= Grow;
        plantSpriteRenderer.sprite = deadPlant; 
    }

    private void SetPlant()
    {
        growthCounter = 1;

        Sprite newPlantSprite = plantData.GetPlantSprite(growthCounter);
        plantSpriteRenderer.sprite = newPlantSprite;

        plantData.CalculatePlantStages();
    }

    public void DestroyPlant()
    {
        Destroy(gameObject);
    }
}
