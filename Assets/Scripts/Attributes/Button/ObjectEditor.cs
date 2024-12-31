using System;
using UnityEditor;

namespace UnityIsBetter.Attributes
{
    [CustomEditor(typeof(Object), true), CanEditMultipleObjects]
    internal class ObjectEditor : Editor
    {
        private ButtonsDrawer _buttonsDrawer;

        private void OnEnable()
        {
            _buttonsDrawer = new ButtonsDrawer(target);    
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            _buttonsDrawer.DrawButtons(targets);
        }
    }
}
