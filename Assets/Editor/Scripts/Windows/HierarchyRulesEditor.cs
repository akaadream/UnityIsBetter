using UnityEditor;
using UnityEngine;
using UnityIsBetter.Editor.Hierarchy;

namespace UnityIsBetter.Editor.Windows
{
    public class HierarchyRulesEditor : EditorWindow
    {
        private const string RulesAssetPathKey = "HierarchyRulesEditor_LastUsedAssetPath";
        private HierarchyColorSettings _settings;

        [MenuItem("Tools/Hierarchy rules editor")]
        public static void ShowWindow()
        {
            var window = GetWindow<HierarchyRulesEditor>("Hierarchy rules editor");
            window.LoadLastUsedAsset();
        }

        private void OnEnable()
        {
            LoadLastUsedAsset();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Hierarchy rules configuration", EditorStyles.boldLabel);
            _settings = (HierarchyColorSettings)EditorGUILayout.ObjectField("Rules asset", _settings, typeof(HierarchyColorSettings), false);

            if (_settings == null)
            {
                if (GUILayout.Button("Create new rules asset"))
                {
                    _settings = CreateNewRulesAsset();
                    SaveLastUsedAssetPath();
                }
                return;
            }

            SaveLastUsedAssetPath();

            EditorGUILayout.Space();

            for (int i = 0; i < _settings.Tags.Count; i++)
            {
                var rule = _settings.Tags[i];

                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField($"Rule {i + 1}", EditorStyles.boldLabel);

                rule.Name = EditorGUILayout.TextField("Name", rule.Name);
                rule.Tag = EditorGUILayout.TagField("Tag", rule.Tag);
                rule.Layer = EditorGUILayout.LayerField("Layer", rule.Layer);
                rule.BackgroundColor = EditorGUILayout.ColorField("Background color", rule.BackgroundColor);

                if (GUILayout.Button("Remove rule"))
                {
                    EditorGUILayout.EndVertical();
                    _settings.Tags.RemoveAt(i);
                    break;
                }
                EditorGUILayout.EndVertical();
            }

            if (GUILayout.Button("Add new rule"))
            {
                _settings.Tags.Add(new HierarchyTagSettings());
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_settings);
            }
        }

        private HierarchyColorSettings CreateNewRulesAsset()
        {
            var path = EditorUtility.SaveFilePanelInProject("Save rules asset", "HierarchyRules", "asset", "Choose a location to save the rule asset.");
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var asset = ScriptableObject.CreateInstance<HierarchyColorSettings>();
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return asset;
        }

        private void LoadLastUsedAsset()
        {
            string lastUsedPath = EditorPrefs.GetString(RulesAssetPathKey, "");
            if (!string.IsNullOrEmpty(lastUsedPath))
            {
                _settings = AssetDatabase.LoadAssetAtPath<HierarchyColorSettings>(lastUsedPath);
            }
        }

        private void SaveLastUsedAssetPath()
        {
            if (_settings != null)
            {
                string path = AssetDatabase.GetAssetPath(_settings);
                if (!string.IsNullOrEmpty(path))
                {
                    EditorPrefs.SetString(RulesAssetPathKey, path);
                }
            }
        }
    }
}
