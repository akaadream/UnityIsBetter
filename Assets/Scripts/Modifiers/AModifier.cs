using UnityEngine;
using UnityIsBetter.Shortcuts;

namespace UnityIsBetter.Modifiers
{
    public abstract class AModifier : ScriptableObject
    {
        /// <summary>
        /// The shortcut object which will be used to apply the modification
        /// </summary>
        [SerializeField]
        protected ShortcutObject ShortcutObject;

        /// <summary>
        /// The method used to transform the T component
        /// </summary>
        /// <param name="component"></param>
        protected abstract void Modify<T>(T component) where T : Component;

        /// <summary>
        /// Modify the given game object if the asked component is found
        /// </summary>
        public virtual void Modify()
        {
            
        }

        protected virtual void Handle<T>() where T : Component
        {
            if (ShortcutObject.TryToFind(out GameObject gameObject))
            {
                if (gameObject.TryGetComponent(out T component))
                {
                    Modify(component);
                }
            }
        }
    }
}
