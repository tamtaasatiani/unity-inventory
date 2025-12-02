using UnityEditor;
using UnityEngine;

namespace Feedbacker
{
    [System.Serializable]
    public class SoundFeedback : Feedback
    {
        [SerializeField] private AudioClip audio;
        [SerializeField] private AudioSource _audioSource;

        public SoundFeedback()
        {
            
        }
        
        public SoundFeedback(Feedbacker feedbacker) : base(feedbacker)
        {
            _audioSource = feedbacker.gameObject.AddComponent<AudioSource>();
            EditorUtility.SetDirty(_audioSource);
        }
        
        public override void Play()
        {
            if (audio == null) return;
            if (_audioSource.clip == null)
                _audioSource.clip = audio;
            
            _audioSource.Play();
        }

        ~SoundFeedback()
        {
            _audioSource.Stop();
            //Destroy(_audioSource);
        }
    }
}
