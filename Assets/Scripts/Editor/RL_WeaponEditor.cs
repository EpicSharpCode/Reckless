using System;
using System.Collections.Generic;
using Reckless.EditorExtension;
using Reckless.Items;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Reckless
{
    [CustomEditor(typeof(RL_Weapon), false)]
    public class RL_WeaponEditor : RL_Editor_MonoBehaviourEditor
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
            
            RL_Weapon weapon = target.GetComponent<RL_Weapon>();
            weapon.selectedItemIndex = EditorGUILayout.Popup("Weapon", weapon.selectedItemIndex, BuildArrayOfWeapons());
            
            if(EditorGUI.EndChangeCheck()) { RL_Editor_Utilities.DonePrefabChanges(weapon); serializedObject.ApplyModifiedProperties();}
        }

        public string[] BuildArrayOfWeapons()
        {
            List<string> names = new (){ "None" };
            var allWeapons = RL_Game_Variables.GetAllWeapons();
            if (allWeapons == null) return names.ToArray();
            for (int i = 0; i<allWeapons.Count; i++)
            {
                names.Add(allWeapons[i].itemName);
            }
            return names.ToArray();
        }
    }
}