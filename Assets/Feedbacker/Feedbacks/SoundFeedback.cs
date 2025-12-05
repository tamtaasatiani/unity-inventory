using BetterAttributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Feedbacker
{
    [System.Serializable]
    public class SoundFeedback : Feedback
    {
        [SerializeField] private AudioClip audio;
        [SerializeField, BetterSlider(0, 100)] private int volume;
        
        [SerializeField, HideInInspector] private AudioSource audioSource;

        public SoundFeedback()
        {
            
        }
        
        public SoundFeedback(Feedbacker feedbacker) : base(feedbacker)
        {
            audioSource = feedbacker.gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            EditorUtility.SetDirty(audioSource);
        }
        
        public override void Play()
        {
            if (audio == null) return;
            if (audioSource.clip == null)
                audioSource.clip = audio;
            
            audioSource.volume = volume / 100f;
            audioSource.Play();
        }
        
        public override void Destroy()
        {
            audioSource.Stop();
            Object.DestroyImmediate(audioSource);
        }
    }
}
