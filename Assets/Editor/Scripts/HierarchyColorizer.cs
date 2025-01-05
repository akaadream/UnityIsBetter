using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Editor.Hierarchy
{
    [InitializeOnLoad]
    public class HierarchyColorizer
    {
        private static HierarchyColorSettings _settings;

        static HierarchyColorizer()
        {
            _settings = Resources.Load<HierarchyColorSettings>("HierarchyRules");
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            if (_settings == null)
            {
                return;
            }

            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null)
            {
                return;
            }

            foreach (var rule in _settings.Tags)
            {
                if (!string.IsNullOrEmpty(rule.Tag) && gameObject.tag != rule.Tag)
                {
                    continue;
                }

                if (rule.Layer == -1 || gameObject.layer != rule.Layer)
                {
                    continue;
                }

                EditorGUI.DrawRect(selectionRect, new Color(0.2196079f, 0.2196079f, 0.2196079f));
                EditorGUI.DrawRect(selectionRect, rule.BackgroundColor);

                Texture2D icon = EditorGUIUtility.ObjectContent(gameObject, typeof(GameObject)).image as Texture2D;
                if (icon != null)
                {
                    Rect iconRect = new Rect(selectionRect.x, selectionRect.y, 16, 16); // Taille standard de l'icône
                    GUI.DrawTexture(iconRect, icon, ScaleMode.ScaleToFit);
                }

                // Dessiner le texte du nom à droite de l'icône
                GUIStyle style = new GUIStyle(EditorStyles.label)
                {
                    normal = { textColor = Color.white },
                    fontStyle = FontStyle.Normal
                };

                Rect textRect = new Rect(selectionRect.x + 18, selectionRect.y, selectionRect.width, selectionRect.height);
                EditorGUI.LabelField(textRect, gameObject.name, style);
            }
        }
    }
}