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
}
