using System;
using System.Collections.Generic;
using Reckless.EditorExtension;
using Reckless.Entities;
using Reckless.Items;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
    [CustomEditor(typeof(BoxEntity), true)]
    public class BoxEntityEditor : MonoBehaviourEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            FindObjectOfType<GameController>().Awake();
            EditorGUI.BeginChangeCheck();
            
            BoxEntity box = target.GetComponent<BoxEntity>();
            box.selectedIndex = EditorGUILayout.Popup(box.boxContentName, box.selectedIndex, box.boxContent.BuildArrayOfItems());
            
            if(EditorGUI.EndChangeCheck()) { EditorUtilities.DonePrefabChanges(box); serializedObject.ApplyModifiedProperties();}
        }
    }
}