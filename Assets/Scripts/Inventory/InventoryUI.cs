using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private InventoryItemUI itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private MouseFollower mouseFollower;

#pragma warning restore 0649

    List<InventoryItemUI> listOfUIItems = new List<InventoryItemUI>();

    private int currentlyDraggedItemIndex = -1;

    public event Action<int> OnDescriptionRequested,
        OnItemActionRequested,
        OnStartDragging;

    public event Action<int, int> OnSwapItems;


    private void Awake()
    {
        mouseFollower.Toggle(false);
    }

    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            InventoryItemUI uiItem =
                Instantiate(itemPrefab);
            uiItem.transform.SetParent(contentPanel);
            uiItem.transform.localScale = new Vector3(1, 1, 1);
            listOfUIItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    public void UpdateData(int itemIndex, 
        Sprite itemSprite, int itemQuantity)
    {
        if (listOfUIItems.Count > itemIndex)
        {
            listOfUIItems[itemIndex].SetData(itemSprite, itemQuantity);
        }
    }

    private void HandleItemSelection(InventoryItemUI inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }

    private void HandleBeginDrag(InventoryItemUI inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);
    }

    private void HandleSwap(InventoryItemUI inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
    }

    private void HandleEndDrag(InventoryItemUI inventoryItemUI)
    {
        ResetDraggedItem();
    }

    private void HandleShowItemActions(InventoryItemUI inventoryItemUI)
    {
        
    }

    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void ResetSelection()
    {
        DeselctAllItems();
    }

    private void DeselctAllItems()
    {
        foreach (InventoryItemUI item in listOfUIItems)
        {
            item.Deselect();
        }
    }
}
