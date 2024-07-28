#if UNITY_EDITOR
using Reckless.Units.AI;
using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
    [CustomPropertyDrawer(typeof(NpcAbilityWithWraper))]
    public class NpcAbilityDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var abilityProperty = property.FindPropertyRelative("ability");

            EditorGUI.BeginProperty(position, label, property);
            Rect abilityRect = new Rect(position.x, position.y, position.width, position.height);
            EditorGUI.PropertyField(abilityRect, abilityProperty, GUIContent.none);
            
            EditorGUI.EndProperty();
        }
    }
}

#endif