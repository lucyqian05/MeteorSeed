﻿using System;
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

    public Sprite sprite;
    public int quantity;
    public string title;

    private void Start()
    {
        testInventory();
    }

    private void Awake()
    {
        mouseFollower.Toggle(false);
    }

    private void testInventory()
    {
        listOfUIItems[0].SetData(sprite, quantity);
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

    private void HandleItemSelection(InventoryItemUI obj)
    {
        Debug.Log(obj.name);
    }

    private void HandleBeginDrag(InventoryItemUI obj)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);
    }

    private void HandleSwap(InventoryItemUI obj)
    {
        
    }

    private void HandleEndDrag(InventoryItemUI obj)
    {
        mouseFollower.Toggle(false);
    }

    private void HandleShowItemActions(InventoryItemUI obj)
    {
        
    }
}
