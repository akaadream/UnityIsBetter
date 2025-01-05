using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace UnityIsBetter.Utils
{
    public static class AssetDatabaseHelper
    {
        public static void CreateFolder(string path)
        {
            if (Directory.Exists(path))
            {
                return;
            }

            Directory.CreateDirectory(path);
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
        }
    }
}
