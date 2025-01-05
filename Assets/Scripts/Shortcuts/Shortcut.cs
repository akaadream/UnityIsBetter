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
        [SerializeField, Header("Shortcut object")]
        private ShortcutObject _shortcutObject;

#if UNITY_EDITOR
        [SerializeField, Disabled]
        private string _currentPath;
#endif

        [Button("Link this reference")]
        public void LinkReference()
        {
            if (_shortcutObject == null)
            {
                _currentPath = string.Empty;
                return;
            }

            _shortcutObject.Path = gameObject.GetPath();

#if UNITY_EDITOR
            UpdateCurrentPath();
#endif
        }

        [Button("Create the shortcut object")]
        public void CreateShortcutObject()
        {
            if (_shortcutObject != null)
            {
                Debug.LogWarning($"[Unity is Better] A shortcut object is already linked to this game object");
                return;
            }

            ShortcutObject shortcutObject = ScriptableObject.CreateInstance<ShortcutObject>();
            shortcutObject.Path = gameObject.GetPath();

            if (!AssetDatabase.AssetPathExists(GetTargetFolderPath()))
            {
                AssetDatabaseHelper.CreateFolder(GetTargetFolderPath());
            }
            
            AssetDatabase.CreateAsset(shortcutObject, GetTargetAssetPath());
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            EditorGUIUtility.PingObject(shortcutObject);
            _shortcutObject = shortcutObject;

            UpdateCurrentPath();
        }

        [Button("Find the already existing shortcut object")]
        public void FindExistingShortcutObject()
        {
            if (!AssetDatabase.AssetPathExists(GetTargetAssetPath()))
            {
                Debug.LogWarning($"[Unity is Better] The shortcut object associated to this game object cannot be find");
                return;
            }

            _shortcutObject = AssetDatabase.LoadAssetAtPath(GetTargetAssetPath(), typeof(ShortcutObject)) as ShortcutObject;
        }

        private string GetTargetFolderPath() => $"Assets/Resources/Shortcuts/{gameObject.scene.name}/{gameObject.name}";
        private string GetTargetAssetPath() => $"{GetTargetFolderPath()}/{gameObject.name}.asset";

#if UNITY_EDITOR
        private void UpdateCurrentPath()
        {
            _currentPath = _shortcutObject.Path;
        }
#endif
    }
}