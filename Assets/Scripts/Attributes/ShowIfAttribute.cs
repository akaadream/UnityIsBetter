using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public class ShowIfAttribute : PropertyAttribute
    {
        public readonly string NameOf;

        public ShowIfAttribute(string nameOf)
        {
            NameOf = nameOf;
        }
    }

    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool? boolValue = GetValue();
            if (boolValue.HasValue)
            {
                if (boolValue.Value)
                {
                    base.OnGUI(position, property, label);
                }
            }
            else
            {
                Debug.LogError("NO VALUE ON THE BOOL");
            }
        }

        public bool? GetValue()
        {
            ShowIfAttribute showIf = attribute as ShowIfAttribute;
            FieldInfo info = typeof(ShowIfAttribute).GetField(showIf.NameOf, BindingFlags.NonPublic);
            return (bool)info.GetValue(showIf);
        }
    }
}
