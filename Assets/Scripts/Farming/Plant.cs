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

    private void Start()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
        plantSpriteRenderer = GetComponent<SpriteRenderer>();
        SetPlant();
    }

    public void Harvest()
    {
        bool doesRegrow = plantData.GetIfPlantRegrows();
        if (!doesRegrow)
        {
            DestroyPlant();
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

    public SO_ItemData GetRatedCrop()
    {
        int daysToGrow = plantData.daysToGrow;
        SO_ItemData bronzeCrop = plantData.ratedCrops[1];

        if (ratingCounter < 0)
        {
            SO_ItemData leadCrop = plantData.ratedCrops[0];
            return leadCrop;
        }
        else if ( 0 <= ratingCounter && ratingCounter < daysToGrow )
        {
            return bronzeCrop;
        }
        else if (daysToGrow <= ratingCounter && ratingCounter < daysToGrow*2)
        {
            SO_ItemData silverCrop = plantData.ratedCrops[2];
            return silverCrop;

        }
        else if (daysToGrow*2 <= ratingCounter && ratingCounter < daysToGrow*3)
        {
            SO_ItemData goldCrop = plantData.ratedCrops[3];
            return goldCrop;
        }
        else if (daysToGrow * 3 <= ratingCounter)
        {
            SO_ItemData galaxyCrop = plantData.ratedCrops[4];
            return galaxyCrop;
        }
        return bronzeCrop;
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
        Debug.Log(polyCollider.OverlapCollider(contactFilter, results));

        if (results != null)
            for (int i = 0; i < results.Count; i++)
            {
                Collider2D neighboringPlantColliders = results[i];
                GameObject neighborPlantGO = neighboringPlantColliders.gameObject;
                Plant neighborPlant = neighborPlantGO.GetComponent<Plant>();
                SO_Plant so_NeighborPlant = neighborPlant.plantData;

                if (companions != null)
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
        results.Clear();

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
