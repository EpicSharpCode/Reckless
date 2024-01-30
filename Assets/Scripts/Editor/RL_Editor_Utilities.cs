using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
    public class RL_Editor_Utilities
    {
        public static void DonePrefabChanges(Object obj)
        {
            EditorUtility.SetDirty(obj);
            PrefabUtility.RecordPrefabInstancePropertyModifications(obj);
        }
    }
}