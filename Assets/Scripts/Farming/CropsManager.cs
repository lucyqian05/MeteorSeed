using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsManager : MonoBehaviour
{
    [SerializeField]
    private FarmLandManager farmLandManager;

    [SerializeField]
    private TimeEventManager timeEventManager;

    [SerializeField]
    private Plant cropPrefab;

    [SerializeField]
    private Transform cropsOrganizer;

    [SerializeField]
    public Dictionary<Vector3Int, Plant> cropManager = new Dictionary<Vector3Int, Plant>();

    private bool waterCheck = false;
    private bool seasonCheck = false;

    private void Start()
    {
        timeEventManager.OnDayChanged += GrowAllCrops;
    }

    private void GrowAllCrops()
    {
        RateCrops(); 

        foreach (var item in cropManager)
        {
            Vector3Int plantLocation = item.Key;
            Plant plant = item.Value;

            CheckWatered(plantLocation);
            CheckSeason(plant);

            if (!seasonCheck)
            {
                plant.KillPlant();
            }
            else if (!waterCheck)
            {
                plant.Unwatered();
            }
            else
            {
                plant.Grow();
            }

            waterCheck = false;
            seasonCheck = false;
        }
    }

    private List<Plant> getValidAdjacentCrops(Vector3Int plantLocation) {
       List<Plant> adjacentPlants = new List<Plant>();

        // Possible directions
        Vector3Int[] directions = new Vector3Int[] {
            Vector3Int.up,
            Vector3Int.down,
            Vector3Int.left,
            Vector3Int.right
        };

        // Iterate over each direction and check if the adjacent tile is valid
        foreach (var direction in directions) {
            Vector3Int adjacentTile = plantLocation + direction;
            // cropManager containing tile means it's valid
            if (cropManager.TryGetValue(adjacentTile, out Plant adjacentPlant))
            {
                adjacentPlants.Add(adjacentPlant);
            }
        }

        return adjacentPlants;
    }

    private void RateCrops()
    {
        foreach (var item in cropManager)
        {
            int totalRate = 0;
            Vector3Int plantLocation = item.Key;
            List<Plant> adjacentCrops = getValidAdjacentCrops(plantLocation);

            PlantData plantData = item.Value.plantData;
            SO_Plant[] companions = plantData.companionPlants;
            SO_Plant[] antagonists = plantData.antagonistPlants;

            foreach (Plant currentAdjacent in adjacentCrops)
            {
                if (companions != null) 
                {
                    foreach (var companion in companions)
                    {
                        if (currentAdjacent.plantData == companion)
                        {
                            totalRate++;
                        }
                    
                    }
                }

                if (antagonists != null) {
                    foreach (var antagonist in antagonists)
                    {  
                        if (currentAdjacent.plantData == antagonist )
                        {
                            totalRate--;
                        }
                    
                    }
                }
            }
            item.Value.ratingCounter += totalRate; 
        }
    }

    private void CheckWatered(Vector3Int plantLocation)
    {
        string farmlandTile = farmLandManager.GetFarmTileState(plantLocation);
        if (farmlandTile == "Biyo")
        {
            waterCheck = true;
        }
    }

    private void CheckSeason(Plant plant)
    {
        string plantingSeason = plant.plantData.GetSeasonString();
        string currentSeason = timeEventManager.currentSeason;

        if(plantingSeason == currentSeason)
        {
            seasonCheck = true;
        }
    }

    public void InstantiatePlant(Vector3Int plantTilePosition, Vector3 plantWorldPosition, SeedUI seed)
    {
        Plant newCrop = Instantiate(cropPrefab, plantWorldPosition, Quaternion.identity);
        newCrop.transform.SetParent(cropsOrganizer);
        newCrop.transform.position = transform.position + new Vector3(plantWorldPosition.x + 0.47f, plantWorldPosition.y + 0.47f, 0);

        SeedUI newSeed = seed;
        SO_Plant newPlantData = newSeed.seed.plant;
        newCrop.plantData = newPlantData;

        newCrop.plantLocation = plantTilePosition;

        cropManager.Add(plantTilePosition, newCrop);
    }

    public bool CheckPlantOnTile(Vector3Int plantTilePosition)
    {
        bool checkPlantOnTile = false;
        foreach (var item in cropManager)
        {
            if(plantTilePosition == item.Key)
            {
                checkPlantOnTile = true;
            }
        }
        return checkPlantOnTile;
    }

    public void RemoveCrop(Vector3Int plantTilePosition)
    {
        foreach (var item in cropManager)
        {
            if (plantTilePosition == item.Key)
            {
                item.Value.DestroyPlant();
            }
        }
        cropManager.Remove(plantTilePosition);
    }
}