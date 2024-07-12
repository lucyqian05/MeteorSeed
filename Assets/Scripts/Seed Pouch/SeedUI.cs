using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SeedUI : MonoBehaviour
{
    [field: SerializeField]
    public SO_Seed seed;

    [field: SerializeField]
    public Image seedImage;

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
        OnSeedDroppedOn, OnSeedBeginDrag, OnSeedEndDrag;

    private bool itemDeselected = true;
    private bool empty = true;

    private void Start()
    {
        SetSeedImage();
    }
    public void SetData()
    {
        int seedQuantity = seed.quantity;
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

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnSeedBeginDrag?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnSeedEndDrag?.Invoke(this);
        OnSeedDroppedOn?.Invoke(this);
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

    private void SetSeedImage()
    {
        seedImage.sprite = seed.seedSprite;
    }

    public void SetQuantity()
    {
        quantityTxt.text = seed.quantity.ToString();
    }
}
