using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class FarmLandManager : MonoBehaviour
{

    [SerializeField]
    private Tilemap plantTilemap;

    [SerializeField]
    private RuleTile agniTile;

    [SerializeField]
    private RuleTile erdeTile;

    [SerializeField]
    private RuleTile biyoTile;

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
            
            farmLand.SetTile(tilePosition, agniTile);

            Color clearTile = new Color(1.0f, 1.0f, 1.0f, 0f);
            plantTilemap.SetTileFlags(tilePosition, TileFlags.None);
            plantTilemap.SetColor(tilePosition, clearTile);
        }
    }

    private void SetLandErde()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = farmLand.WorldToCell(worldPoint);
        TileBase tile = farmLand.GetTile(tilePosition);

        if (tile != null)
        {
            farmLand.SetTile(tilePosition, erdeTile);
        }
    }

    private void SetLandBiyo()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = farmLand.WorldToCell(worldPoint);
        TileBase tile = farmLand.GetTile(tilePosition);

        if (tile != null)
        {
            farmLand.SetTile(tilePosition, biyoTile);
        }
    }
}
