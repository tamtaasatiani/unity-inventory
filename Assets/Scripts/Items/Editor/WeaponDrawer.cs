using UnityEditor;
using UnityEngine;

namespace Items.Editor
{
    [CustomPropertyDrawer(typeof(StatData))]
    public class StatDrawer : PropertyDrawer
    {
        private SerializedProperty _damageProperty;

        private float _totalHeight = 0;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            SetProperties(property);
            
            Rect damagePosition =  new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            _damageProperty.intValue = EditorGUI.IntSlider(damagePosition, new GUIContent("Damage"), _damageProperty.intValue, Constants.MIN_DAMAGE, Constants.MAX_DAMAGE);
            
            _totalHeight = damagePosition.y + damagePosition.height;
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _totalHeight;
        }

        private void SetProperties(SerializedProperty property)
        {
            _damageProperty = property.FindPropertyRelative("damage");
        }
    }
}

