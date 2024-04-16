using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

<<<<<<< HEAD
=======
<<<<<<< HEAD
        private UnityEngine.InputSystem.PlayerInput playerInput;
        private InputAction controllerInputAction;
=======
#pragma warning restore 0649
>>>>>>> parent of 3e0cbbe (Inventory)

>>>>>>> 66ad28c8f441243dc44dd1b9fceec1b229e8c0f8
        public event Action<InventoryItemUI> OnItemClicked,
            OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
<<<<<<< HEAD
            OnRightMouseBtnClick;
=======
            OnConsume;
>>>>>>> parent of b6291be (Inventory Update)

        private bool empty = true;
        private bool itemDeselected = true;

        public void Awake()
        {
            ResetData();
<<<<<<< HEAD
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.OnEat += OnItemEat;
        }

        private void OnItemEat(InputAction.CallbackContext obj)
        {
            if (itemDeselected == false)
                OnItemActionRequested?.Invoke(this);
=======
<<<<<<< HEAD
=======
            playerInput = GetComponent<PlayerInput>();
            controllerInputAction = playerInput.actions["Eat"];
>>>>>>> parent of b6291be (Inventory Update)
>>>>>>> 66ad28c8f441243dc44dd1b9fceec1b229e8c0f8
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

<<<<<<< HEAD
        public void OnPointerClick(BaseEventData data)
=======
        public void OnActionEat(BaseEventData data)
>>>>>>> parent of b6291be (Inventory Update)
        {
            if (empty)
                return;
            //if (itemDeselected == false && controllerInputAction.triggered)
            //{
            //    OnConsume?.Invoke(this);
            //}

            PointerEventData pointerData = (PointerEventData)data;
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
<<<<<<< HEAD
                OnRightMouseBtnClick?.Invoke(this);
=======
                OnConsume?.Invoke(this);
>>>>>>> parent of b6291be (Inventory Update)
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }
    }
}