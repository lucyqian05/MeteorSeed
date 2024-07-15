using Inventory.Model;
using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu]
public class SO_Plant : ScriptableObject
{
    [Header("Plant Information")]
    public string plantName;

#pragma warning disable 0649

    [SerializeField]
    Season season = new Season();

    public Sprite[] plantStageSprite;

    public SO_ItemData so_Crop;

    [Header("Crop Information")]
    public SO_ItemData[] ratedCrops;
    public int numberOfCrops;

    [field: SerializeField]
    public SO_Plant[] companionPlants { get; set; }

    [field: SerializeField]
    public SO_Plant[] antagonistPlants { get; set; }

    [Header("Growth Information")]
    public int daysToGrow;

    [SerializeField]
    private bool doesRegrow = false;

    private const int plantStageSeed = 1;
    private const int plantStageOne = 2;
    private int plantStageTwo;
    private int plantStageThree;
    private int plantStageFour;

    private Sprite currentSprite; 

    public string GetSeasonString()
    {
        string plantSeason = season.ToString(); 
        return plantSeason;
    }

    public int GetStageTwoInt()
    {
        return plantStageTwo; 
    }

    public List<Sprite> GetCompanionSprites()
    {
        List<Sprite> companionSprite = new List<Sprite>();
        for (int i = 0; i < companionPlants.Length; i++)
        {
            Sprite comSprite;

            comSprite = companionPlants[i].ratedCrops[1].Image;
            companionSprite.Add(comSprite);
        }
        return companionSprite;
    }

    public List<Sprite> GetAntagonistSprites()
    {
        List<Sprite> antagonistSprite = new List<Sprite>();
        for (int i = 0; i < companionPlants.Length; i++)
        {
            Sprite antSprite;

            antSprite = antagonistPlants[i].ratedCrops[1].Image;
            antagonistSprite.Add(antSprite);
        }
        return antagonistSprite;
    }

    public bool GetIfPlantRegrows()
    {
        return doesRegrow;
    }

    public Sprite GetPlantSprite(int growthCounter)
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
        } else if (growthCounter >= plantStageFour)
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
        } else if (daysRemain == 1)
        {
            plantStageThree++;
        } else if (daysRemain == 2)
        {
            plantStageTwo++;
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
