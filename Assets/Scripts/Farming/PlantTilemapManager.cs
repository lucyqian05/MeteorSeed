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
    private SeedController seedController;

    [SerializeField]
    private Tile plantPlaceholder;

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

            Vector3 cropSpawn = plantTilemap.CellToWorld(new Vector3Int(item.Key.x, item.Key.y, 0));

            Plant newCrop = Instantiate(cropPrefab, cropSpawn, Quaternion.identity);
            newCrop.transform.SetParent(cropsOrganizer);
            newCrop.transform.position = transform.position + new Vector3(cropSpawn.x + 0.47f, cropSpawn.y + 0.47f, 0);

            SeedUI newSeed = item.Value;
            SO_Plant newPlantData = newSeed.seed.plant;
            newCrop.plantData = newPlantData;

            newCrop.plantLocation = item.Key;
            newCrop.farmlandTilemap = farmTilemap;
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
        TileBase tile = plantTilemap.GetTile(tilePosition);

        Color tileColor = plantTilemap.GetColor(tilePosition);

        Sprite seedImage = seed.seedImage.sprite;

        Tile tempTile = ScriptableObject.CreateInstance<Tile>();
        Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);

        if (tile != null && tileColor == clearTile && tile != plantPlaceholder)
        {
            tempTile.sprite = seedImage;
            plantTilemap.SetTile(tilePosition, tempTile);
            tempSeedMap.Add(tilePosition, seed);
        }
    }
}
