using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UnityIsBetter.Attributes
{
    public class Button
    {
        public readonly string DisplayName;
        public readonly MethodInfo Method;
        public readonly ButtonAttribute ButtonAttribute;

        public Button(MethodInfo method, ButtonAttribute buttonAttribute)
        {
            ButtonAttribute = buttonAttribute;
            Method = method;
            DisplayName = string.IsNullOrEmpty(buttonAttribute.Name) ? ObjectNames.NicifyVariableName(method.Name) : buttonAttribute.Name;
        }

        internal void Draw(IEnumerable<object> targets)
        {
            if (!GUILayout.Button(DisplayName)) return;

            foreach (object target in targets)
            {
                Method.Invoke(target, null);
            }
        }
    }
}
