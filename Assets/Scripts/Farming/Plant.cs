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
            plantWatered = true;
        }
    }

    private void CheckSeason()
    {
        string season = plantData.GetSeasonString();

        //get access to dateTime and check the season 
    }

    public void Grow()
    {
        CheckWatered();

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

        if(growthCounter <= plantData.daysToGrow)
        {
            growthCounter++;
            Sprite newPlantSprite = plantData.GetPlantSprite(growthCounter);
            plantSpriteRenderer.sprite = newPlantSprite;
            plantWatered = false;
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
