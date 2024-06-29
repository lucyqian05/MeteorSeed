using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SeedMouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private SeedUI seedPrefab;

    [SerializeField]
    private Image seedImage; 

    private PlayerInput playerInput;
    private InputAction controllerInputAction;

    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controllerInputAction = playerInput.actions["MousePosition"];
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

    public void SetData(SeedUI draggedSeed)
    {
        seedImage.sprite = draggedSeed.seedImage.sprite;
    }

    public void Toggle(bool val)
    {
        gameObject.SetActive(val);
    }
}
