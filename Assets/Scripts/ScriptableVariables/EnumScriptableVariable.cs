using System;

namespace UnityIsBetter.ScriptableVariables
{
    public abstract class EnumScriptableVariable<T> : AScriptableVariable<T> where T : Enum
    {
    }
}
