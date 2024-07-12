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

    public Vector3Int plantLocation;

    private SpriteRenderer plantSpriteRenderer;

    private int growthCounter;

    public bool plantWatered = false;
    public int daysUnwatered;
    private const int unwateredPlantDeath = 3;

    public bool readyForHarvest = false;

    public Action<SO_ItemData> CropProduced;

    private void Start()
    {
        plantSpriteRenderer = GetComponent<SpriteRenderer>();
        SetPlant();
    }

    public void Harvest()
    {
        if (!plantData.doesRegrow)
        {
            return;
        } 
        else
        {
            growthCounter = plantData.GetStageTwoInt();
            Sprite newPlantSprite = plantData.GetPlantSprite(growthCounter);
            plantSpriteRenderer.sprite = newPlantSprite;
        }
        readyForHarvest = false;
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

    public void Grow()
    {
        if(growthCounter < plantData.daysToGrow)
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

    public void Unwatered()
    {
        daysUnwatered++;
        if (daysUnwatered >= unwateredPlantDeath)
        {
            KillPlant();
            return;
        }
    }
    public void KillPlant()
    {
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
