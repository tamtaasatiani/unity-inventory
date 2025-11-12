using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]
public class ItemEditor : Editor
{
    SerializedProperty damage;
    SerializedProperty sprite;
    
    void OnEnable()
    {
        damage = serializedObject.FindProperty("_damage");
        sprite = serializedObject.FindProperty("_sprite");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.IntSlider(damage, 0, 100, new GUIContent("Damage"));
        EditorGUILayout.PropertyField(sprite, new GUIContent("Sprite"));
        
        serializedObject.ApplyModifiedProperties();
    }
}
