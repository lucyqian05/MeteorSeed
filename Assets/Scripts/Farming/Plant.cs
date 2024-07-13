using Inventory.Model;
using System;
using System.Collections.Generic;
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
    public int ratingCounter = 0; 

    public bool plantWatered = false;
    public int daysUnwatered;
    private const int unwateredPlantDeath = 3;

    public bool readyForHarvest = false;

    private PolygonCollider2D polyCollider; 

    public Action<SO_ItemData> CropProduced;

    private void Start()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
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

    public void RateAdjacentCrops()
    {
        SO_Plant[] companions = plantData.companionPlants;
        SO_Plant[] antagonists = plantData.antagonistPlants;

        //I haven't used ContactFilter so I'm not going to try to learn it right now. It filters which colliders to listen to. 
        ContactFilter2D contactFilter = new ContactFilter2D().NoFilter();

        List<Collider2D> results = new List<Collider2D>(); 
        polyCollider.OverlapCollider(contactFilter, results);

        for (int i = 0; i < results.Count; i++)
        {
            Collider2D neighboringPlantColliders = results[i];
            GameObject neighborPlantGO = neighboringPlantColliders.gameObject;
            Plant neighborPlant = neighborPlantGO.GetComponent<Plant>();
            SO_Plant so_NeighborPlant = neighborPlant.plantData;

            if(companions != null)
            {
                for (int j = 0; j < companions.Length; j++)
                {
                    if (companions[j] == so_NeighborPlant)
                    {
                        ratingCounter++;
                    }
                }
            }
            
            if (antagonists != null)
            {
                for (int jj = 0; jj < antagonists.Length; jj++)
                {
                    if (antagonists[jj] == so_NeighborPlant)
                    {
                        ratingCounter--;
                    }
                }
            }
        }
    }

    public void Unwatered()
    {
        daysUnwatered++;
        ratingCounter--;
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
