using UnityEditor;
using UnityEngine;
using UnityIsBetter.Attributes;
using UnityIsBetter.Utils;

namespace UnityIsBetter.Shortcuts
{
    public class Shortcut : MonoBehaviour
    {
        /// <summary>
        /// The shortcut object associated with the shortcut (must be unique)
        /// </summary>
        [SerializeField]
        private ShortcutObject _shortcutObject;

        [SerializeField, HideIf(nameof(_shortcutObject))]
        private string _test;

#if UNITY_EDITOR
        [SerializeField, Disabled]
        private string _currentPath;

        private void OnEnable()
        {
            UpdateCurrentPath();
        }
#endif

        [Button("Link this reference")]
        public void LinkReference()
        {
            _shortcutObject.Path = gameObject.GetPath();

#if UNITY_EDITOR
            UpdateCurrentPath();
#endif
        }

        [Button("Create the shortcut object", showIf: nameof(_shortcutObject))]
        public void CreateShortcutObject()
        {
            ShortcutObject shortcutObject = new()
            {
                Path = gameObject.GetPath()
            };
            AssetDatabase.CreateFolder($"Assets/Resources/Shortcuts", gameObject.name);
            AssetDatabase.CreateAsset(shortcutObject, $"Assets/Resources/Shortcuts/{gameObject.name}/{gameObject.name}.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = shortcutObject;
            _shortcutObject = shortcutObject;
        }

#if UNITY_EDITOR
        private void UpdateCurrentPath()
        {
            _currentPath = _shortcutObject.Path;
        }
#endif
    }
}