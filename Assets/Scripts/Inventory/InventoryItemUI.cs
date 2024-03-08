using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class InventoryItemUI : MonoBehaviour
    {
        [SerializeField]
        private Image border;

        [SerializeField]
        private Image itemImage;

        [SerializeField]
        private GameObject quantityGO;

        [SerializeField]
        private TMP_Text quantityTxt;

        private PlayerInput playerInput;
        private InputAction controllerInputAction;

        public event Action<InventoryItemUI> OnItemClicked,
            OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
            OnItemActionRequested;

        private bool empty = true;
        private bool itemDeselected = true;

        public void Awake()
        {
            ResetData();
            playerInput = GetComponent<PlayerInput>();
            controllerInputAction = playerInput.actions["Eat"];
        }

        public void Update()
        {
            if(itemDeselected == false && controllerInputAction.triggered)
            {
                OnItemActionRequested?.Invoke(this);
            }
        }

        public void SetData(Sprite sprite, int quantity)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            if (quantity == 1)
            {
                quantityGO.SetActive(false);
            }
            else
            {
                quantityTxt.text = quantity + "";
                quantityGO.SetActive(true);
            }

            empty = false;
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

        public void ResetData()
        {
            itemImage.gameObject.SetActive(false);
            empty = true;
            itemDeselected = true;
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

        public void OnActionSelect(BaseEventData data)
        {
            if (empty)
                return;
            PointerEventData pointerData = (PointerEventData)data;
            if (pointerData.button == PointerEventData.InputButton.Left)
            {
                OnItemClicked?.Invoke(this);
            }
        }
    }
}