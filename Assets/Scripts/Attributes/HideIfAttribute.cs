using System;
using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class HideIfAttribute : PropertyAttribute
    {
        public readonly string NameOf;

        public HideIfAttribute(string nameOf)
        {
            NameOf = nameOf;
        }
    }

    [CustomPropertyDrawer(typeof(HideIfAttribute))]
    public class HideIfDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (ShouldDisplay(property))
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }

            return 0;

        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (ShouldDisplay(property))
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        private bool ShouldDisplay(SerializedProperty property)
        {
            HideIfAttribute conditional = (HideIfAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.NameOf);

            return conditionProperty != null && !DisplayAttributeHelper.ShouldDisplay(conditionProperty);
        }
    }

}