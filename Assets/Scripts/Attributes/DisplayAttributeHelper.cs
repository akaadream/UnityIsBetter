using UnityEditor;

namespace UnityIsBetter.Attributes
{
    public static class DisplayAttributeHelper
    {
        public static bool ShouldDisplay(SerializedProperty conditionProperty)
        {
            return conditionProperty.propertyType switch
            {
                SerializedPropertyType.Boolean => conditionProperty.boolValue,
                SerializedPropertyType.Integer => conditionProperty.intValue != 0,
                SerializedPropertyType.Float => conditionProperty.floatValue != 0,
                SerializedPropertyType.String => !string.IsNullOrEmpty(conditionProperty.stringValue),
                SerializedPropertyType.ObjectReference => conditionProperty.objectReferenceValue != null,
                SerializedPropertyType.ManagedReference => conditionProperty.managedReferenceValue != null,
                _ => conditionProperty.objectReferenceInstanceIDValue != 0,
            };
        }
    }
}
