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
    private PlayerInput playerInput;
    private GameObject player; 

    private void Start()
    {
        farmLand = GetComponent<Tilemap>();
        playerInput = GetComponent<PlayerInput>();

        player = GameObject.FindWithTag("Player");
        magic = player.GetComponent<Magic>();


        magic.OnAgni += SetLandAgni;
        magic.OnErde += SetLandErde;
        magic.OnBiyo += SetLandBiyo;

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

            bool plantOnTile = false;

            foreach (var item in cropManager.cropManager)
            {
                if (tilePosition == item.Key)
                {
                    item.Value.DestroyPlant();
                    plantOnTile = true; 
                }
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
