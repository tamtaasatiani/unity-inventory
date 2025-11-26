using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Feedbacker))]
public class FeedbackerEditor : Editor
{
    private enum FeedbackType
    {
        Sound,
        Animation
    }
    
    private String selectedFeedbackTypeMenuText;
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        GUILayout.BeginHorizontal();
        GenerateMenu();
        if (GUILayout.Button("Add Feedback"))
        {
            
        }
        GUILayout.EndHorizontal();
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void GenerateMenu()
    {
        String buttonText = selectedFeedbackTypeMenuText != null ? selectedFeedbackTypeMenuText : "Select";
        
        if (!GUILayout.Button(buttonText)) return;
        
        GenericMenu feedbackTypeMenu = new GenericMenu();

        String[] feedbackTypes = Enum.GetNames(typeof(FeedbackType));

        foreach (String fType in feedbackTypes)
        {
            feedbackTypeMenu.AddItem(new GUIContent(fType), true, () =>
            {
                selectedFeedbackTypeMenuText = fType;
            });
        }
            
        feedbackTypeMenu.ShowAsContext();
    }
}
