using Reckless.UI;
using UnityEditor;
using UnityEngine;

namespace Reckless.Editor
{
    [CustomPropertyDrawer(typeof(RL_UI_ViewHandler), true)]
    public class RL_UI_ViewHandlerDrawer : PropertyDrawer
    {
        const float spacing = 10;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var viewNameProperty = property.FindPropertyRelative("viewName");
            var viewProperty = property.FindPropertyRelative("view");
            var showByDefaultProperty = property.FindPropertyRelative("showByDefault");

            EditorGUI.BeginProperty(position, label, property);

            Rect viewNameRect = new Rect(position.x, position.y, 150, position.height);
            Rect showByDefaultRect = new Rect(viewNameRect.x + viewNameRect.width + spacing, position.y, 20, viewNameRect.height);
            Rect viewRect = new Rect(showByDefaultRect.x + showByDefaultRect.width + spacing, showByDefaultRect.y, 
                position.width - viewNameRect.width - showByDefaultRect.width - 20, position.height);

            EditorGUI.PropertyField(viewNameRect, viewNameProperty, GUIContent.none);
            EditorGUI.PropertyField(showByDefaultRect, showByDefaultProperty, GUIContent.none);
            EditorGUI.PropertyField(viewRect, viewProperty, GUIContent.none);
            
            EditorGUI.EndProperty();
        }
    }
}