using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTilemapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap plantTilemap;

    [SerializeField]
    private Tilemap farmTilemap;

    [SerializeField]
    private FarmLandManager farmLandManager;

    [SerializeField]
    private SeedController seedController;

    [SerializeField]
    private Tile plantPlaceholder;

    [SerializeField]
    private CropsManager cropsManager;

    [SerializeField]
    private Transform cropsOrganizer;

    [SerializeField]
    private Plant cropPrefab;

    private Dictionary<Vector3Int, SeedUI> tempSeedMap = new Dictionary<Vector3Int, SeedUI>();

    public void Start()
    {
        seedController.SeedDropped += HandleSeedDropped;
    }

    public void InstantiatePlant()
    {
        foreach(var item in tempSeedMap)
        {
            plantTilemap.SetTile(item.Key, plantPlaceholder);
            Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);
            plantTilemap.SetTileFlags(item.Key, TileFlags.None);
            plantTilemap.SetColor(item.Key, clearTile);

            Vector3 cropWorldPosition = plantTilemap.CellToWorld(new Vector3Int(item.Key.x, item.Key.y, 0));

            cropsManager.InstantiatePlant(item.Key, cropWorldPosition, item.Value);            
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
            }        
        }
    }
}
