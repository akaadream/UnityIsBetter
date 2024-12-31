using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    [Conditional("UNITY_EDITOR")]
    public class ButtonAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly string Row;
        public readonly float Space;
        public readonly bool HasRow;

        public ButtonAttribute(string name = default, string row = default, float space = default)
        {
            Name = name;
            Row = row;
            HasRow = !string.IsNullOrEmpty(row);
            Space = space;
        }
    }

    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.DrawRect(position, Color.red);
        }
    }
}
