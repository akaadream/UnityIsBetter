using System.Collections.Generic;
using UnityEngine;

namespace UnityIsBetter.Editor.Hierarchy
{
    [CreateAssetMenu(fileName = "HierarchyColorSettings", menuName = "Unity is Better/Settings/Hierarchy Colors")]
    public class HierarchyColorSettings : ScriptableObject
    {
        public List<HierarchyTagSettings> Tags = new(); 
    }
}
