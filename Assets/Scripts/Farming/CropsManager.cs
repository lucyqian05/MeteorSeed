using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap farmTilemap;

    [SerializeField]
    private Plant cropPrefab;

    [SerializeField]
    private Transform cropsOrganizer;

    [SerializeField]
    public Dictionary<Vector3Int, Plant> cropManager = new Dictionary<Vector3Int, Plant>();

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

        newCrop.farmlandTilemap = farmTilemap;
    }
}
