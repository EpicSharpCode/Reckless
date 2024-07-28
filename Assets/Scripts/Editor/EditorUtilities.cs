using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
    public class EditorUtilities
    {
        public static void DonePrefabChanges(Object obj)
        {
            EditorUtility.SetDirty(obj);
            PrefabUtility.RecordPrefabInstancePropertyModifications(obj);
        }
    }
}