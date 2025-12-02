using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Feedbacker
{
    [System.Serializable]
    public class SoundFeedback : Feedback
    {
        [SerializeField] private AudioClip audio;
        
        [SerializeField, HideInInspector] private AudioSource audioSource;

        public SoundFeedback()
        {
            
        }
        
        public SoundFeedback(Feedbacker feedbacker) : base(feedbacker)
        {
            audioSource = feedbacker.gameObject.AddComponent<AudioSource>();
            EditorUtility.SetDirty(audioSource);
        }
        
        public override void Play()
        {
            if (audio == null) return;
            if (audioSource.clip == null)
                audioSource.clip = audio;
            
            audioSource.Play();
        }

        ~SoundFeedback()
        {
            audioSource.Stop();
            //Destroy(_audioSource);
        }
    }
}
