using UnityEngine;
using UnityIsBetter.Attributes;
using UnityIsBetter.Utils;

namespace UnityIsBetter.Shortcuts
{
    public class Shortcut : MonoBehaviour
    {
        /// <summary>
        /// The shortcut object associated with the shortcut (must be unique)
        /// </summary>
        [SerializeField]
        private ShortcutObject _shortcutObject;

        [SerializeField]
        private bool _isChild;

        [SerializeField, ShowIf(nameof(_shortcutObject))]
        private string _test;

        [Button("Link this reference")]
        public void LinkReference()
        {
            _shortcutObject.Path = gameObject.GetPath();
        }
    }
}