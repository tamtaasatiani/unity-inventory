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

        private Dictionary<FeedbackType, Type> _feedbackTypes;

        private SerializedProperty feedbacksProperty;

        private void OnEnable()
        {
            //_feedbacker.RemoveAllFeedbacks();
            _feedbacker = target as Feedbacker;
            if (_feedbacker == null) Debug.LogError("Feedbacker missing");
            
            _feedbackTypes =  new Dictionary<FeedbackType, Type>()
            {
                [FeedbackType.Sound] = typeof(SoundFeedback),
                [FeedbackType.Animation] = typeof(AnimationFeedback)
            };
            
            feedbacksProperty = serializedObject.FindProperty("_feedbacks");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            ListFeedbacks();
            
            GUILayout.BeginHorizontal();
            GenerateMenu();
            if (GUILayout.Button("Add Feedback"))
            {
                AddFeedback(feedbacksProperty, _feedbackTypes[_selectedFeedbackType]);
                //_feedbacker.GetFeedbacks()[0].Fire();
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

            int removeIndex = -1;

            for (int i = 0; i < _feedbacker.Feedbacks.Count; i++)
            {
                if (_feedbacker.Feedbacks[i] == null) continue;
                GUILayout.BeginHorizontal();
                //EditorGUILayout.LabelField(_feedbacker.Feedbacks[i].GetType().Name);
                EditorGUILayout.PropertyField(feedbacksProperty.GetArrayElementAtIndex(i), new GUIContent(_feedbacker.Feedbacks[i].GetType().Name), true);
                if (GUILayout.Button("X"))
                {
                    removeIndex = i;
                }
                GUILayout.EndHorizontal();
            }

            RemoveFeedback(feedbacksProperty, removeIndex);
        }

        private void AddFeedback(SerializedProperty fProperty, Type type)
        {
            int newIndex = fProperty.arraySize;
            fProperty.InsertArrayElementAtIndex(newIndex);
            
            object[] args = {_feedbacker};
            
            SerializedProperty newItemProp = feedbacksProperty.GetArrayElementAtIndex(newIndex);
            newItemProp.managedReferenceValue = Activator.CreateInstance(type, args);
        }
        
        private void RemoveFeedback(SerializedProperty fProperty, int index)
        {
            if (index < 0 || index >= _feedbacker.Feedbacks.Count) return;
            fProperty.DeleteArrayElementAtIndex(index);
            //fProperty.DeleteArrayElementAtIndex(index);
            
            serializedObject.ApplyModifiedProperties();
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
