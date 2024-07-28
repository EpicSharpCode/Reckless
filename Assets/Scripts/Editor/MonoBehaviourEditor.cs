#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
    [CustomEditor(typeof(MonoBehaviour), editorForChildClasses:true)]
    public class MonoBehaviourEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            DrawPropertiesExcluding(serializedObject, "m_Script");
            if(EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif