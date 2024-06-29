using Inventory.Model;
using UnityEngine;
using DateAndTime;
using System;

[CreateAssetMenu]
public class SO_Plant : ScriptableObject
{
    [Header("Plant Information")]
    public string plantName;

#pragma warning disable 0649

    [SerializeField]
    Season season = new Season();

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

    private int growthCounter = 1; 
    private int reproduceCounter;
    private bool plantWatered = false;
    private int daysUnwatered;
    private int unwateredPlantDeath = 3; 

    public void Start()
    {
        CalculatePlantStages();
    }

    private void PlantGrowth(TimeManager.DateTime dateTime)
    {
        if (!plantWatered)
        {
            daysUnwatered++;
            if (daysUnwatered == unwateredPlantDeath)
            {
                KillPlant();
            }
        }
        growthCounter++; 

    }

    private void KillPlant()
    {
        //TimeManager.OnDayChanged -= PlantGrowth;
        //When the plant script is created, the sprite should be updated to be dead
    }

    private void CalculatePlantStages()
    {
        double dividedDays = (daysToGrow - 2) / 3;
        int daysEven = (int)Math.Round(dividedDays);
        int daysRemain = (daysToGrow - 2) % 3;

        plantStageTwo = daysEven;
        plantStageThree = daysEven;
        plantStageFour = daysEven; 
        
        if(daysRemain == 0)
        {
            return; 
        } else if (daysRemain == 1)
        {
            plantStageFour++;
        } else if (daysRemain == 2)
        {
            plantStageFour++;
            plantStageThree++;
        }
    }

    enum Season
    {
        Freshbud,
        Bloom, 
        Glowlush,
        Sparktip,
        Jubilee
    }
}
