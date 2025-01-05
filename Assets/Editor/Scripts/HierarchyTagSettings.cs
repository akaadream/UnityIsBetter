using System;
using UnityEngine;

namespace UnityIsBetter.Editor.Hierarchy
{
    [Serializable]
    public class HierarchyTagSettings
    {
        public string Name;
        public string Tag;
        public int Layer = 0;
        public Color BackgroundColor = Color.clear;
    }
}
