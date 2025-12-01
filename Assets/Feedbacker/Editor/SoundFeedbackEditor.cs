/*
namespace Feedbacker.Editor
{
    [CustomEditor(typeof(SoundFeedback))]
    public class SoundFeedbackEditor : FeedbackEditor
    {
        private SerializedProperty _testProperty;
        
        private void OnEnable()
        {
            _testProperty = serializedObject.FindProperty("testField");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(_testProperty);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
*/