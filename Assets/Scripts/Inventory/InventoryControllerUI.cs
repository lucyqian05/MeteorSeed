using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerUI : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField]
    private InventoryUI inventoryUI;
    #pragma warning restore 0649

    public int inventorySize = 10;
    
    private void Awake()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

    public void Update()
    {
        
    }

}
