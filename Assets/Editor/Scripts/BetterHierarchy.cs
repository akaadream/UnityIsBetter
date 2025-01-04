using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class BetterHierarchy : MonoBehaviour
{
    static BetterHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    private static void OnHierarchyGUI(int instanceId, Rect selectionRect)
    {
        Event e = Event.current;
        if (e == null)
        {
            return;
        }

        if (!selectionRect.Contains(e.mousePosition))
        {
            return;
        }

        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
        if (gameObject == null)
        {
            return;
        }

        // Clicked on item with middle click
        if (IsMiddleButtonUp(e))
        {
            gameObject.SetActive(!gameObject.activeSelf);
            e.Use();
        }
    }

    // Mouse left click
    private static bool IsLeftButtonDown(Event e) => e != null && e.type == EventType.MouseDown && e.button == 1;
    private static bool IsLeftButtonUp(Event e) => e != null && e.type == EventType.MouseUp && e.button == 1;
    
    // Mouse middle click
    private static bool IsMiddleButtonDown(Event e) => e != null && e.type == EventType.MouseDown && e.button == 2;
    private static bool IsMiddleButtonUp(Event e) => e != null && e.type == EventType.MouseUp && e.button == 2;

    // Mouse right click
    private static bool IsRightButtonDown(Event e) => e != null && e.type == EventType.MouseDown && e.button == 3;
    private static bool IsRightButtonUp(Event e) => e != null && e.type == EventType.MouseUp && e.button == 3;
}
