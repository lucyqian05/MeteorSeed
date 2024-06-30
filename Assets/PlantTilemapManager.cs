using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTilemapManager : MonoBehaviour
{
    [SerializeField]
    private SO_PlantTilemap plantDatabase;

    [SerializeField]
    private Tilemap plantTilemap;

    [SerializeField]
    private SeedController seedController;

    public void Start()
    {
        seedController.SeedDropped += HandleSeedDropped;
    }

    public void HandleSeedDropped(SeedUI seed)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = plantTilemap.WorldToCell(worldPoint);
        TileBase tile = plantTilemap.GetTile(tilePosition);

        Sprite seedImage = seed.seedImage.sprite;

        Tile tempTile = ScriptableObject.CreateInstance<Tile>();

        if (tile != null)
        {

            tempTile.sprite = seedImage;

            plantTilemap.SetTile(tilePosition, tempTile);
        }
    }
}
