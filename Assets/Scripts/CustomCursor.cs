using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorImage; // The custom cursor image
    [SerializeField] private Vector2 hotSpot = Vector2.zero; // Hotspot for the cursor (pivot point)
    [SerializeField] private CursorMode cursorMode = CursorMode.Auto; // Cursor mode (Auto/ForceSoftware)

    void Start()
    {
        // Set the custom cursor
        Cursor.SetCursor(cursorImage, hotSpot, cursorMode);
    }

    public void ResetCursor()
    {
        // Reset to the default system cursor
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
