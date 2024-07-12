using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTilemapManager : MonoBehaviour
{
    [Header("Tilemap")]

    [SerializeField]
    private Tilemap plantTilemap;

    [Header("Managers")]

    [SerializeField]
    private FarmLandManager farmLandManager;

    [SerializeField]
    private CropsManager cropsManager;

    [SerializeField]
    private SeedController seedController;

    [Header("Tiles")]

    [SerializeField]
    private Tile plantPlaceholder;

    [SerializeField]
    private Tile noPlantPlaceholder;

    private Dictionary<Vector3Int, SeedUI> tempSeedMap = new Dictionary<Vector3Int, SeedUI>();

    Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);

    public void Start()
    {
        seedController.SeedDropped += HandleSeedDropped;
    }

    public bool CheckClearTile(Vector3Int tilePosition)
    {
        bool plantClear = false;
        Color plantColor = plantTilemap.GetColor(tilePosition);

        if(plantColor == clearTile)
        {
            plantClear = true;
            return plantClear;
        }
        return plantClear;
    }

    public void SetNoPlantPlaceholder(Vector3Int tilePosition)
    {
        plantTilemap.SetTile(tilePosition, noPlantPlaceholder);
        plantTilemap.SetTileFlags(tilePosition, TileFlags.None);
        plantTilemap.SetColor(tilePosition, clearTile);
    }

    public void InstantiatePlant()
    {
        foreach(var item in tempSeedMap)
        {
            plantTilemap.SetTile(item.Key, plantPlaceholder);
            Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);
            plantTilemap.SetTileFlags(item.Key, TileFlags.None);
            plantTilemap.SetColor(item.Key, clearTile);

            Vector3 plantWorldPosition = plantTilemap.CellToWorld(new Vector3Int(item.Key.x, item.Key.y, 0));

            cropsManager.InstantiatePlant(item.Key, plantWorldPosition, item.Value);            
        }
        tempSeedMap.Clear();
        seedController.tempSeedQuantityHold.Clear();
    }

    public void CancelSeed()
    {
        foreach (var item in tempSeedMap)
        {
            SetNoPlantPlaceholder(item.Key);
        }
        tempSeedMap.Clear();
    }

    public void SpreadSeed()
    {
        tempSeedMap.Clear(); 
    }

    public void HandleSeedDropped(SeedUI seed)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = plantTilemap.WorldToCell(worldPoint);
        TileBase plantTile = plantTilemap.GetTile(tilePosition);
        string farmTileState = farmLandManager.GetFarmTileState(tilePosition);

        Color tileColor = plantTilemap.GetColor(tilePosition);

        Sprite seedImage = seed.seedImage.sprite;

        Tile tempTile = ScriptableObject.CreateInstance<Tile>();
        Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);

        bool seedSet = false;

        foreach (var item in tempSeedMap)
        {
            if (tilePosition == item.Key)
            {
                seedSet = true; 
            }
        }

        if (plantTile != null && plantTile != plantPlaceholder && farmTileState != "Agni")
        {
            if(seedSet || tileColor == clearTile)
            {
                tempTile.sprite = seedImage;
                plantTilemap.SetTile(tilePosition, tempTile);
                tempSeedMap.Remove(tilePosition);
                tempSeedMap.Add(tilePosition, seed);

                seedController.AddTempSeedData(seed);
                
                seed.seed.UpdateQuantity(-1);
                seed.SetData();
            }        
        }
    }
}
