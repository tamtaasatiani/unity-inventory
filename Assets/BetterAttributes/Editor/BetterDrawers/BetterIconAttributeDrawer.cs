using UnityEditor;
using UnityEngine;
using BetterAttributes;

namespace BetterDrawers
{
    [CustomPropertyDrawer(typeof(BetterIconAttribute))]
    public class BetterIconAttributeDrawer : PropertyDrawer
    {
        private float _squareSide = EditorGUIUtility.singleLineHeight * 4;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            Rect iconPosition = new Rect(EditorGUIUtility.currentViewWidth - _squareSide, position.y, _squareSide, _squareSide);
            property.objectReferenceValue = EditorGUI.ObjectField(iconPosition, property.objectReferenceValue, typeof(Sprite), false);
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _squareSide + EditorGUIUtility.singleLineHeight;
        }
    }
}
