using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Inventory.UI
{
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


        public event Action<InventoryItemUI> OnItemClicked,
            OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
            OnItemActionRequested, OnRightMouseBtnClick;

        private bool empty = true;
        private bool itemDeselected = true;

        public void Awake()
        {
            ResetData();
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.OnEat += OnItemEat;
        }

        private void OnItemEat(InputAction.CallbackContext obj)
        {
            if (itemDeselected == false)
                OnItemActionRequested?.Invoke(this);

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

        public void OnPointerClick(BaseEventData data)
        {
            if (empty)
                return;

            PointerEventData pointerData = (PointerEventData)data;
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }
    }
}