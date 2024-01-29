#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UnityParallaxLibrary.EditorExtension
{
    [CustomEditor(typeof(Object), editorForChildClasses:true)]
    public class RL_Editor_ObjectEditor : Editor
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