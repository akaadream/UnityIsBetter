using UnityEngine;
using UnityEngine.Events;
using UnityIsBetter.Attributes;

namespace UnityIsBetter.ScriptableVariables.VariableEvents
{
    public abstract class AVariableEvent<T> : MonoBehaviour
    {
        [SerializeField]
        protected AScriptableVariable<T> ScriptableVariable;

        [ShowIf(nameof(ScriptableVariable))]
        public UnityEvent<T> OnChanged;

        private void OnEnable()
        {
            OnChanged.AddListener(OnScriptableVariableChanged);
        }

        private void OnDisable()
        {
            OnChanged.RemoveListener(OnScriptableVariableChanged);
        }

        private void OnScriptableVariableChanged(T newValue)
        {
            OnChanged?.Invoke(newValue);
        }
    }
}
