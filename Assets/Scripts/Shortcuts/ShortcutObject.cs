using UnityEngine;

namespace UnityIsBetter.Shortcuts
{
    [CreateAssetMenu(fileName = "Shortcut", menuName = "Unity is Better/Shortcut")]
    public class ShortcutObject : ScriptableObject
    {
        /// <summary>
        /// The path of the linked game object (must be unique)
        /// </summary>
        [SerializeField]
        public string Path;

        // Get the game object corresponding with the path
        public GameObject Find()
        {
            return GameObject.Find(Path);
        }
    }

}