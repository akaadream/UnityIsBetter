using UnityEngine;
using UnityEngine.Events;
using UnityIsBetter.Attributes;

namespace UnityIsBetter.ScriptableVariables
{
    public abstract class AScriptableVariable<T> : ScriptableObject
    {
        public UnityEvent<T> OnUpdate;

        public T Current
        {
            get => _current;
            set
            {
                Previous = _showPrevious = _current;
                _current = _showCurrent = value;
                OnUpdate?.Invoke(value);
            }
        }
        private T _current;

        public T Previous { get; protected set; }

        [SerializeField]
        public T Initial;

#if UNITY_EDITOR
        [SerializeField]
        private string _description;

        [SerializeField, Disabled]
        private T _showCurrent;

        [SerializeField, Disabled]
        private T _showPrevious;
#endif

        private void OnEnable()
        {
            Reinitialize();
        }

        private void OnDisable()
        {
            Reinitialize();
        }

        protected virtual void Reinitialize()
        {
            Current = Initial;
        }
    }
}
