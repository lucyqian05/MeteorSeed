using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class FarmLandManager : MonoBehaviour
{
    [SerializeField]
    private CropsManager cropManager;

    [SerializeField]
    private Tilemap plantTilemap;

    [SerializeField]
    private RuleTile agniTile;

    [SerializeField]
    private RuleTile erdeTile;

    [SerializeField]
    private RuleTile biyoTile;

    [SerializeField]
    private Tile agniTileTag;

    private Tilemap farmLand;
    private Magic magic;
    private GameObject player; 

    private void Start()
    {
        farmLand = GetComponent<Tilemap>();

        player = GameObject.FindWithTag("Player");
        magic = player.GetComponent<Magic>();

        magic.OnAgni += SetLandAgni;
        magic.OnErde += SetLandErde;
        magic.OnBiyo += SetLandBiyo;
    }

    public string GetFarmTileState(Vector3Int tilePosition)
    {
        TileBase farmTile = farmLand.GetTile(tilePosition);
        string farmState;
        if (farmTile != null)
        {
            
            if (farmTile == agniTile)
            {
                farmState = "Agni";
                return farmState;
            }
            else if (farmTile == erdeTile)
            {
                farmState = "Erde";
                return farmState;
            }
            else if (farmTile == biyoTile)
            {
                farmState = "Biyo";
                return farmState;
            }
        }
        farmState = "Empty";
        return farmState;
    }
    
    private void SetLandAgni()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = farmLand.WorldToCell(worldPoint);
        TileBase tile = farmLand.GetTile(tilePosition); 

        if(tile != null)
        {
            Color plantColor = plantTilemap.GetColor(tilePosition);
            Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);

            bool plantOnTile = cropManager.CheckPlantOnTile(tilePosition);

            if (plantOnTile)
            {
                cropManager.RemoveCrop(tilePosition);
            }

            if (plantColor != clearTile || plantOnTile)
            {
                farmLand.SetTile(tilePosition, agniTile);

                plantTilemap.SetTile(tilePosition, agniTileTag);

                plantTilemap.SetTileFlags(tilePosition, TileFlags.None);
                plantTilemap.SetColor(tilePosition, clearTile);
            }
        }
    }

    private void SetLandErde()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = farmLand.WorldToCell(worldPoint);
        TileBase tile = farmLand.GetTile(tilePosition);

        if (tile != null)
        {
            if(tile == agniTile)
            {
                farmLand.SetTile(tilePosition, erdeTile);
            } 
        }
    }

    private void SetLandBiyo()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = farmLand.WorldToCell(worldPoint);
        TileBase tile = farmLand.GetTile(tilePosition);

        if (tile != null)
        {
            if(tile == erdeTile)
            {
                farmLand.SetTile(tilePosition, biyoTile);
            }           
        }
    }
}
