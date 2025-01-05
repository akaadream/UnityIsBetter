using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Attributes
{
    public class OnChangedAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public OnChangedAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(OnChangedAttribute))]
    public class OnChangedAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);
            if (EditorGUI.EndChangeCheck())
            {
                OnChangedAttribute onChangedAttribute = attribute as OnChangedAttribute;
                IEnumerable<MethodInfo> methods = property.serializedObject.targetObject.GetType().GetMethods(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.DeclaredOnly).Where(m => m.Name == onChangedAttribute.MethodName);
                if (methods.Count() > 0)
                {
                    foreach (MethodInfo method in methods)
                    {
                        if (method != null && method.GetParameters().Count() == 0)
                        {
                            method.Invoke(property.serializedObject.targetObject, null);
                        }
                    }
                }
            }
        }
    }
#endif
}