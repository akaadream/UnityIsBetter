using UnityEngine;
using UnityIsBetter.Attributes;

namespace UnityIsBetter.Modifiers
{
    [CreateAssetMenu(fileName = "TransformModifier", menuName = "Unity is Better/Modifiers/Transform modifier")]
    public class TransformModifier : AModifier
    {
        [SerializeField]
        private bool _modifyPosition;

        [SerializeField, ShowIf(nameof(_modifyPosition))]
        private Vector3 _position;

        [SerializeField]
        private bool _modifyRotation;

        [SerializeField, ShowIf(nameof(_modifyRotation))]
        private Vector3 _rotation;

        protected override void Modify<T>(T component)
        {
            Transform transform = component as Transform;
            if (transform == null)
            {
                return;
            }

            if (_modifyPosition)
            {
                transform.position = _position;
            }

            if (_modifyRotation)
            {
                transform.rotation = Quaternion.Euler(_rotation);
            }
        }

        public override void Modify()
        {
            Handle<Transform>();
        }
    }
}
