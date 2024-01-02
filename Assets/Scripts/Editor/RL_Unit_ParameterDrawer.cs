#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Reckless.Editor
{
    [CustomPropertyDrawer(typeof(RL_Unit_Parameter))]
    public class RL_Unit_ParameterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var parameterName = property.FindPropertyRelative("parameterName");
            var value = property.FindPropertyRelative("value");
            var minValue = property.FindPropertyRelative("minValue");
            var maxValue = property.FindPropertyRelative("maxValue");

            EditorGUI.BeginProperty(position, label, property);

            Rect parameterNameRect = new Rect(position.x, position.y, 50, position.height);
            Rect valueRect = new Rect(parameterNameRect.x + parameterNameRect.width + 10, parameterNameRect.y, 150, parameterNameRect.height);
            
            GUI.Label(parameterNameRect,parameterName.stringValue);
            GUI.Label(valueRect, $"{System.Math.Round(value.floatValue / maxValue.floatValue * 100)}%\t"
                                 + $"({System.Math.Round(value.floatValue, 1)}/" +
                                 $"{System.Math.Round(maxValue.floatValue, 1)})");
            
            
            EditorGUI.EndProperty();
        }
    }
}

#endif