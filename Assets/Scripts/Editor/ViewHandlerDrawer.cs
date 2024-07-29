using Reckless.UI;
using UnityEditor;
using UnityEngine;

namespace Reckless.EditorExtension
{
[CustomPropertyDrawer(typeof(UiViewHandler), true)]
public class ViewHandlerDrawer : PropertyDrawer
{
const float SPACING = 10;

public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
{
    var viewNameProperty = property.FindPropertyRelative("_viewName");
    var viewProperty = property.FindPropertyRelative("_view");
    var showByDefaultProperty = property.FindPropertyRelative("_showByDefault");

    EditorGUI.BeginProperty(position, label, property);

    Rect viewNameRect = new Rect(position.x, position.y, 150, position.height);
    Rect showByDefaultRect = new Rect(viewNameRect.x + viewNameRect.width + SPACING, position.y, 20, viewNameRect.height);
    Rect viewRect = new Rect(showByDefaultRect.x + showByDefaultRect.width + SPACING, showByDefaultRect.y,
        position.width - viewNameRect.width - showByDefaultRect.width - 20, position.height);

    EditorGUI.PropertyField(viewNameRect, viewNameProperty, GUIContent.none);
    EditorGUI.PropertyField(showByDefaultRect, showByDefaultProperty, GUIContent.none);
    EditorGUI.PropertyField(viewRect, viewProperty, GUIContent.none);

    EditorGUI.EndProperty();
}
    }
}