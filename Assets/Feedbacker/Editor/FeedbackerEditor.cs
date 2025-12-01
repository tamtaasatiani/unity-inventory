using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Feedbacker.Editor
{
    [CustomEditor(typeof(Feedbacker))]
    public class FeedbackerEditor : UnityEditor.Editor
    {
        private enum FeedbackType
        {
            Sound,
            Animation
        }
        
        //private Dictionary<FeedbackType, Type> _feedbackList = new Dictionary<FeedbackType, Type>()
        //{
        //    [FeedbackType.Sound] = typeof(SoundFeedback)
        //};
        
        private FeedbackType _selectedFeedbackType;
        private Feedbacker _feedbacker;

        private Dictionary<FeedbackType, Action> _feedbackTypes;
        //{
        //    [FeedbackType.Sound] = () => _feedbacker.AddSoundFeedback()
        //};

        private void OnEnable()
        {
            _feedbacker = target as Feedbacker;
            if (_feedbacker == null) Debug.LogError("Feedbacker missing");
            
            _feedbackTypes =  new Dictionary<FeedbackType, Action>()
            {
                [FeedbackType.Sound] = () => _feedbacker.AddSoundFeedback()
            };
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            ListFeedbacks();
            
            GUILayout.BeginHorizontal();
            GenerateMenu();
            if (GUILayout.Button("Add Feedback"))
            {
                _feedbackTypes[_selectedFeedbackType]?.Invoke();
                _feedbacker.GetFeedbacks()[0].Fire();
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
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(feedback.GetType().Name);
                if (GUILayout.Button("X"))
                {
                    feedback.RemoveFlag = true;
                }
                GUILayout.EndHorizontal();
            }

            _feedbacker.RemoveFlaggedFeedbacks();
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

}
