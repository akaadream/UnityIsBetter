using UnityEngine;

namespace UnityIsBetter.Utils
{
    public static class GameObjectExtensions
    {
        public static string GetPath(this GameObject gameObject, bool prefix = true)
        {
            string path = $"{gameObject.name}";
            while (gameObject.transform.parent != null)
            {
                gameObject = gameObject.transform.parent.gameObject;
                path = $"{gameObject.name}/{path}";
            }
            if (prefix)
            {
                path = $"/{path}";
            }
            return path;
        }
    }
}
