using System;
using System.Collections.Generic;
using Reckless.EditorExtension;
using Reckless.Items;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Reckless
{
    [CustomEditor(typeof(Items.Weapon), false)]
    public class WeaponMonoBehaviourEditor : MonoBehaviourEditor
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
            
            Items.Weapon weapon = target.GetComponent<Items.Weapon>();
            weapon._selectedItemIndex = EditorGUILayout.Popup("Weapon", weapon._selectedItemIndex, BuildArrayOfWeapons());
            
            if(EditorGUI.EndChangeCheck()) { EditorUtilities.DonePrefabChanges(weapon); serializedObject.ApplyModifiedProperties();}
        }

        public string[] BuildArrayOfWeapons()
        {
            List<string> names = new (){ "None" };
            var allWeapons = GameVariables.GetAllWeapons();
            if (allWeapons == null) return names.ToArray();
            for (int i = 0; i<allWeapons.Count; i++)
            {
                names.Add(allWeapons[i]._itemName);
            }
            return names.ToArray();
        }
    }
}