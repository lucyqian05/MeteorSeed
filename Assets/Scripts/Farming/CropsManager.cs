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

    private void RateCrops()
    {
        foreach (var item in cropManager)
        {
            int totalRate = 0;

            Vector3Int upperTile = item.Key + Vector3Int.up;
            Vector3Int lowerTile = item.Key + Vector3Int.down;
            Vector3Int leftTile = item.Key + Vector3Int.left;
            Vector3Int rightTile = item.Key + Vector3Int.right;

            Vector3Int[] adjacentCrops =
            {
                upperTile,
                lowerTile,
                leftTile,
                rightTile
            };
            
            SO_Plant[] companions = item.Value.plantData.companionPlants;
            SO_Plant[] antagonists = item.Value.plantData.antagonistPlants;

            for (int i = 0; i < adjacentCrops.Length; i++)
            {
                if (cropManager.ContainsKey(adjacentCrops[i]))
                {
                    for (int j = 0; j < companions.Length; j++)
                    {
                        if (companions != null)
                        {
                            if (cropManager[adjacentCrops[i]].plantData == companions[j])
                            {
                                totalRate++;
                            }
                        }
                    }

                    for (int k = 0; k < antagonists.Length; k++)
                    {
                        if(antagonists != null)
                        {
                            if (cropManager[adjacentCrops[i]].plantData == antagonists[k])
                            {
                                totalRate--;
                            }
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
