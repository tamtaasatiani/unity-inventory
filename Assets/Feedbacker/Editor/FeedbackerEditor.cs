using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    private Dictionary<FeedbackType, Type> _feedbackList = new Dictionary<FeedbackType, Type>()
    {
        [FeedbackType.Sound] = typeof(SoundFeedback)
    };
    
    private FeedbackType _selectedFeedbackType;
    private Feedbacker _feedbacker;

    private void OnEnable()
    {
        _feedbacker = target as Feedbacker;
        if (_feedbacker == null) Debug.LogError("Feedbacker missing");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        ListFeedbacks();
        
        GUILayout.BeginHorizontal();
        GenerateMenu();
        if (GUILayout.Button("Add Feedback"))
        {
            //_feedbackList[_selectedFeedbackType];
            //Feedback fb = new Feedback(_feedbacker);
            //_feedbacker.AddFeedback(new Feedback(_feedbacker));
        }
        GUILayout.EndHorizontal();
        
        serializedObject.ApplyModifiedProperties();
    }

    private void ListFeedbacks()
    {
        EditorGUILayout.LabelField("Feedbacks:", EditorStyles.boldLabel);

        if (_feedbacker == null)
        {
            Debug.LogError("Feedbacker missing");
            return;
        }

        foreach (Feedback feedback in _feedbacker.Feedbacks)
        {
            if (feedback == null) return;
            EditorGUILayout.LabelField(feedback.GetType().Name);
        }
    }
    
    private void GenerateMenu()
    {
        String buttonText = _selectedFeedbackType != null ? _selectedFeedbackType.ToString() : "Select";
        
        if (!GUILayout.Button(buttonText)) return;
        
        GenericMenu feedbackTypeMenu = new GenericMenu();

        FeedbackType[] feedbackTypes = Enum.GetValues(typeof(FeedbackType)).Cast<FeedbackType>().ToArray();

        foreach (FeedbackType fType in feedbackTypes)
        {
            feedbackTypeMenu.AddItem(new GUIContent(fType.ToString()), true, () =>
            {
                _selectedFeedbackType = fType;
            });
        }
            
        feedbackTypeMenu.ShowAsContext();
    }
}
