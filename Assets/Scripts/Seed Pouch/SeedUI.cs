using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SeedUI : MonoBehaviour
{
    [SerializeField]
    private Image seedImage;

    [SerializeField]
    private string seedName;

    [SerializeField]
    private int seedQuantity;

    [SerializeField]
    private SO_Crop crop;

    [SerializeField]
    private Image border;

    [SerializeField]
    private GameObject quantityUI;

    [SerializeField]
    private TMP_Text quantityTxt;

    [SerializeField]
    private Color emptySeed;

    [SerializeField]
    private Color seedColor;

    public event Action<SeedUI> OnSeedClicked,
        OnSeedDroppedOn, OnSeedBeginDrag, OnSeedEndDrag,
        OnRightMouseBtnClick;

    private bool itemDeselected = true;
    private bool empty = true;

    public void SetData(int addedSeed)
    {
        seedQuantity += addedSeed;
        
        if (seedQuantity == 1)
        {
            quantityUI.SetActive(false);
            seedImage.color = seedColor;
            empty = false;
        }
        else if (seedQuantity > 1)
        {
            quantityUI.SetActive(true);
            quantityTxt.text = seedQuantity + "";
            seedImage.color = seedColor;
            empty = false;
        }
        else
        {
            empty = true;
            seedImage.color = emptySeed;
        }
    }

    public void OnPointerClick(BaseEventData data)
    {
        if (empty)
            return;
        OnSeedClicked?.Invoke(this);
    }

    public void OnDrop()
    {
        OnSeedDroppedOn?.Invoke(this);
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnSeedBeginDrag?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnSeedEndDrag?.Invoke(this);
    }

    public void Selection()
    {
        if (itemDeselected)
        {
            border.enabled = true;
            itemDeselected = false;
        }
        else
        {
            border.enabled = false;
            itemDeselected = true;
        }
    }
    public void Deselect()
    {
        border.enabled = false;
    }

}
