using Inventory.Model;
using UnityEngine;
using DateAndTime;
using System;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SO_Plant : ScriptableObject
{
    [Header("Plant Information")]
    public string plantName;

#pragma warning disable 0649

    [SerializeField]
    public Season season = new Season();

    public Sprite[] plantStageSprite;

    [Header("Crop Information")]
    public SO_Consumable crop;
    public int numberOfCrops;

    [field: SerializeField]
    public SO_Plant[] companionPlants { get; set; }

    [field: SerializeField]
    public SO_Plant[] antagonistPlants { get; set; }

    [Header("Growth Information")]
    public int daysToGrow;
    public int daysToRegrow;

    private const int plantStageSeed = 1;
    private const int plantStageOne = 2;
    private int plantStageTwo;
    private int plantStageThree;
    private int plantStageFour;

    private Sprite currentSprite; 

    public int growthCounter; 
    private int reproduceCounter;

    public bool plantWatered;
    public int daysUnwatered;
    public int unwateredPlantDeath;

    public Sprite GetPlantSprite()
    {
        if (growthCounter == plantStageSeed)
        {
            currentSprite = plantStageSprite[0]; 
        } 
        else if (growthCounter == plantStageOne)
        {
            currentSprite = plantStageSprite[1];
        } 
        else if (growthCounter == plantStageTwo)
        {
            currentSprite = plantStageSprite[2];
        }
        else if (growthCounter == plantStageThree)
        {
            currentSprite = plantStageSprite[3];
        } 
        else if (growthCounter == plantStageFour)
        {
            currentSprite = plantStageSprite[4];
        }

        return currentSprite;
    }

    public void CalculatePlantStages()
    {
        double dividedDays = (daysToGrow - 2) / 3;
        int daysEven = (int)Math.Round(dividedDays);
        int daysRemain = (daysToGrow - 2) % 3;

        plantStageTwo = plantStageOne + daysEven;
        plantStageThree = plantStageTwo + daysEven;
        plantStageFour = daysToGrow;
        
        if(daysRemain == 0)
        {
            return; 
        } 
        else if (daysRemain == 1)
        {
            plantStageThree++;
        } 
        else if (daysRemain == 2)
        {
            plantStageTwo++;
            plantStageThree++;
        }
    }

    public enum Season
    {
        Freshbud,
        Bloom, 
        Glowlush,
        Sparktip,
        Jubilee
    }
}
