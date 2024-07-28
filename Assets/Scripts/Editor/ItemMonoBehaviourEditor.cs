using System;
using System.Collections.Generic;
using Reckless.EditorExtension;
using Reckless.Items;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
    [CustomEditor(typeof(Item), false)]
    public class ItemMonoBehaviourEditor : MonoBehaviourEditor
    {
        void OnEnable()
        {
            FindObjectOfType<GameVariables>().Awake();
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            FindObjectOfType<GameVariables>().Awake();
            EditorGUI.BeginChangeCheck();
            
            Item item = target.GetComponent<Item>();
            item._selectedItemIndex = EditorGUILayout.Popup("Item", item._selectedItemIndex, BuildArrayOfItems());
            
            if(EditorGUI.EndChangeCheck()) { EditorUtilities.DonePrefabChanges(item); serializedObject.ApplyModifiedProperties();}
        }

        public string[] BuildArrayOfItems()
        {
            List<string> names = new (){ "None" };
            var allItems = GameVariables.GetAllItems();
            if (allItems == null) return names.ToArray();
            for (int i = 0; i<allItems.Count; i++)
            {
                names.Add(allItems[i]._itemName);
            }
            return names.ToArray();
        }
    }
}