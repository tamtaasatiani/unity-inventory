using BetterAttributes;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;

namespace BetterDrawers
{
    [CustomPropertyDrawer(typeof(BetterSliderAttribute))]
    public class BetterSliderAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!ValidProperty(property)) return;
                
            EditorGUI.BeginProperty(position, label, property);
            
            Rect sliderPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            
            BetterSliderAttribute betterSliderAttribute = (BetterSliderAttribute)attribute;
            property.intValue = EditorGUI.IntSlider(sliderPosition, label, property.intValue, betterSliderAttribute.Min, betterSliderAttribute.Max);
            
            EditorGUI.EndProperty();
        }

        private bool ValidProperty(SerializedProperty property)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                Debug.LogError("BetterSlider can only be used with an integer");
                return false;
            }
            
            return true;
        }
    }
}