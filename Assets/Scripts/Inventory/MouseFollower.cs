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

    private Vector2 mousePosition;

#pragma warning restore 0649

    public void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        item = GetComponentInChildren<InventoryItemUI>();
        mousePosition = Mouse.current.position.ReadValue();
    }

    public void SetData(Sprite sprite, int quantity)
    {
        item.SetData(sprite, quantity);
    }

    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            mousePosition,
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
