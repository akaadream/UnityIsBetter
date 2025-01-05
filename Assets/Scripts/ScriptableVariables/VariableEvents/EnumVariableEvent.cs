using System;

namespace UnityIsBetter.ScriptableVariables.VariableEvents
{
    public abstract class EnumVariableEvent<T> : AVariableEvent<T> where T : Enum
    {
    }
}
