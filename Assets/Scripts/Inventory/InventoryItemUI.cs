using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField]
    private Image border;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private GameObject quantityGO;

    [SerializeField]
    private TMP_Text quantityTxt;

#pragma warning restore 0649

    public event Action<InventoryItemUI> OnItemClicked,
        OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
        OnRightMouseBtnClick;

    private bool empty = true;

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        if (quantity == 1)
        {
            quantityGO.SetActive(false);
        }
        else
        {
            this.quantityTxt.text = quantity + "";
            quantityGO.SetActive(true);
        }
        
        empty = false; 
    }
    
    public void Select()
    {

    }

    public void Deselect()
    {

    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        if(pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
