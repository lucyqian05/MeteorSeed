using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SeedPouchUI : MonoBehaviour
{
    [SerializeField]
    private Image border;

    [SerializeField]
    private GameObject quantity;

    [SerializeField]
    private TMP_Text quantityTxt;

    public event Action<SeedPouchUI> OnSeedClicked,
        OnSeedDroppedOn, OnSeedBeginDrag, OnSeedEndDrag,
        OnRightMouseBtnClick;

    private bool empty = true;
    private bool itemDeselected = true;



}
