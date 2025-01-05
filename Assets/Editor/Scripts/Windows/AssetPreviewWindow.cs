using UnityEditor;
using UnityEngine;

public class AssetPreviewWindow : EditorWindow
{
    private Object _previewObject;
    private Texture2D _previewTexture;

    [MenuItem("Window/Asset Preview")]
    public static void ShowWindow()
    {
        GetWindow<AssetPreviewWindow>("Asset Preview");
    }

    private void OnGUI()
    {
        if (_previewObject == null)
        {
            EditorGUILayout.LabelField("Hover an asset to see its preview");
        }
        else
        {
            EditorGUILayout.ObjectField($"Asset", _previewObject, typeof(Object), false);

            if (_previewTexture != null)
            {
                GUILayout.Label(_previewTexture, GUILayout.Width(position.width), GUILayout.Height(position.height));
            }
            else
            {
                EditorGUILayout.LabelField("No preview available.");
            }
        }
    }

    public void UpdatePreview(Object asset)
    {
        if (_previewObject == asset)
        {
            return;
        }

        _previewObject = asset;
        _previewTexture = AssetPreview.GetAssetPreview(asset) ?? AssetPreview.GetMiniThumbnail(asset);
        Repaint();
    }
}
