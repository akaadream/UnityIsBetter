using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class AssetHoverDetector : MonoBehaviour
{
    static AssetHoverDetector()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
    }

    private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
    {
        if (selectionRect.Contains(Event.current.mousePosition))
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

            //AssetPreviewWindow previewWindow = EditorWindow.GetWindow<AssetPreviewWindow>();
            //previewWindow.UpdatePreview(asset);
        }
    }
}
