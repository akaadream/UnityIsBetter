using UnityEngine;
using UnityEngine.Events;

namespace UnityIsBetter.Modifiers
{
    public class Modifier : MonoBehaviour
    {
        [SerializeField]
        private AModifier _modifier;

        public UnityEvent OnModify;

        private void OnEnable()
        {
            OnModify.AddListener(Modify);
        }

        private void OnDisable()
        {
            OnModify.RemoveListener(Modify);
        }

        public void Modify()
        {
            if (_modifier == null)
            {
                return;
            }

            _modifier.Modify();
        }
    }
}
