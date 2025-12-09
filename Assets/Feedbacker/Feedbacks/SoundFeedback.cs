using System.Threading;
using BetterAttributes;
using Cysharp.Threading.Tasks;
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
            bool hasAudioSource = feedbacker.TryGetComponent<AudioSource>(out AudioSource source);
            audioSource = hasAudioSource ? source : feedbacker.gameObject.AddComponent<AudioSource>();
            
            if (!hasAudioSource)
            {
                audioSource.playOnAwake = false;
                EditorUtility.SetDirty(audioSource);
            }
        }
        
        public override async UniTask Play(CancellationToken cancellationToken = default)
        {
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource attached");
                return;
            }
            if (audio == null)
            {
                Debug.LogError("AudioClip not provided");
                return;
            }
            if (audioSource.clip == null)
                audioSource.clip = audio;
            
            audioSource.volume = volume / 100f;
            audioSource.Play();
            
            while (audioSource.isPlaying)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.DelayFrame(1);
            }
        }
        
        //public override void Destroy()
        //{
        //    audioSource.Stop();
        //    Object.DestroyImmediate(audioSource);
        //}
    }
}
