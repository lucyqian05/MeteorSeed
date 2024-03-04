using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private InventoryItemUI item;

    private PlayerInput playerInput;
    private InputAction controllerInputAction;

#pragma warning restore 0649

    public void Awake()
    {
        item = GetComponentInChildren<InventoryItemUI>();
        playerInput = GetComponent<PlayerInput>();
        controllerInputAction = playerInput.actions["MousePosition"];

    }

    public void SetData(Sprite sprite, int quantity)
    {
        item.SetData(sprite, quantity);
    }

    void Update()
    {
        Vector2 readValue = controllerInputAction.ReadValue<Vector2>();

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            readValue,
            canvas.worldCamera,
            out position
                );
        transform.position = canvas.transform.TransformPoint(position);



    }

    public void Toggle(bool val)
    {
        Debug.Log($"item toggled {val}");
        gameObject.SetActive(val);

    }
}
