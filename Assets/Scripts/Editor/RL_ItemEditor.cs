using System;
using System.Collections.Generic;
using Reckless.EditorExtension;
using Reckless.Items;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Reckless
{
    [CustomEditor(typeof(RL_Item), false)]
    public class RL_ItemEditor : RL_Editor_MonoBehaviourEditor
    {
        void OnEnable()
        {
            FindObjectOfType<RL_Game_Variables>().Awake();
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            FindObjectOfType<RL_Game_Variables>().Awake();
            EditorGUI.BeginChangeCheck();
            
            RL_Item item = target.GetComponent<RL_Item>();
            item.selectedItemIndex = EditorGUILayout.Popup("Item", item.selectedItemIndex, BuildArrayOfItems());
            
            if(EditorGUI.EndChangeCheck()) { RL_Editor_Utilities.DonePrefabChanges(item); serializedObject.ApplyModifiedProperties();}
        }

        public string[] BuildArrayOfItems()
        {
            List<string> names = new (){ "None" };
            var allItems = RL_Game_Variables.GetAllItems();
            if (allItems == null) return names.ToArray();
            for (int i = 0; i<allItems.Count; i++)
            {
                names.Add(allItems[i].itemName);
            }
            return names.ToArray();
        }
    }
}