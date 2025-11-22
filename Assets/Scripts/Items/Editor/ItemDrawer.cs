using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Drawers
{
    [CustomPropertyDrawer(typeof(NameData))]
    public class NameDrawer : PropertyDrawer
    {
        private SerializedProperty _nameProperty;
        
        private SerializedProperty _iconProperty;
        private SerializedProperty _displayNameProperty;
        private SerializedProperty _descriptionProperty;
        
        private float _totalHeight = 0;
            
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            SetProperties(property);
            
            float squareSide = EditorGUIUtility.singleLineHeight * 4;
            
            Rect iconPosition = new Rect(EditorGUIUtility.currentViewWidth - squareSide, position.y + EditorGUIUtility.singleLineHeight, squareSide, squareSide);
            _iconProperty.objectReferenceValue = EditorGUI.ObjectField(iconPosition, _iconProperty.objectReferenceValue, typeof(Sprite), false);
            
            Rect displayNamePosition = new Rect(position.x, iconPosition.y + iconPosition.height + EditorGUIUtility.singleLineHeight,  position.width, EditorGUIUtility.singleLineHeight);
            _displayNameProperty.stringValue = EditorGUI.TextField(displayNamePosition, new GUIContent("Display Name"), _displayNameProperty.stringValue);
            
            Rect descriptionPosition = new Rect(position.x, displayNamePosition.y + displayNamePosition.height + EditorGUIUtility.singleLineHeight / 3, position.width, EditorGUIUtility.singleLineHeight * 2);
            _descriptionProperty.stringValue = EditorGUI.TextField(descriptionPosition, new GUIContent("Description"), _descriptionProperty.stringValue);
            
            _totalHeight = descriptionPosition.y + descriptionPosition.height + EditorGUIUtility.singleLineHeight;
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _totalHeight;
        }

        private void SetProperties(SerializedProperty property)
        {
            _nameProperty = property.FindPropertyRelative("name");
            
            _iconProperty = property.FindPropertyRelative("icon");
            _displayNameProperty = property.FindPropertyRelative("displayName");
            _descriptionProperty = property.FindPropertyRelative("description");
        }
    }
}
