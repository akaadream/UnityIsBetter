using System;
using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class ButtonAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly string Row;
        public readonly float Space;
        public readonly bool HasRow;
        public readonly string ShowIf;
        public readonly string HideIf;
        public readonly bool UseShowIf;
        public readonly bool UseHideIf;

        public ButtonAttribute(string name = default, string row = default, float space = default, string showIf = default, string hideIf = default)
        {
            Name = name;
            Row = row;
            HasRow = !string.IsNullOrEmpty(row);
            Space = space;
            ShowIf = showIf;
            if (!string.IsNullOrEmpty(showIf))
            {
                UseShowIf = true;
                UseHideIf = false;
            }

            HideIf = hideIf;
            if (!string.IsNullOrEmpty(hideIf))
            {
                UseHideIf = true;
                UseShowIf = false;
            }
        }
    }

    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ButtonAttribute conditional = (ButtonAttribute)attribute;
            if (conditional.UseHideIf && ShouldHide(property))
            {
                return 0f;
            }

            if (conditional.UseShowIf && !ShouldDisplay(property))
            {
                return 0f;
            }

            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ButtonAttribute conditional = (ButtonAttribute)attribute;
            if (conditional.UseHideIf && ShouldHide(property))
            {
                return;
            }

            if (conditional.UseShowIf && !ShouldDisplay(property))
            {
                return;
            }

            EditorGUI.DrawRect(position, Color.red);
        }

        private bool ShouldHide(SerializedProperty property)
        {
            ButtonAttribute conditional = (ButtonAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.HideIf);
            return conditionProperty != null && DisplayAttributeHelper.ShouldDisplay(conditionProperty);
        }

        private bool ShouldDisplay(SerializedProperty property)
        {
            ButtonAttribute conditional = (ButtonAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ShowIf);
            return conditionProperty != null && DisplayAttributeHelper.ShouldDisplay(conditionProperty);
        }
    }
}
