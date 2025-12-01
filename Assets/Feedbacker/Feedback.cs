using UnityEngine;

namespace Feedbacker
{
    [System.Serializable]
    public class Feedback : ScriptableObject
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        protected bool _removeFlag = false;
        protected Feedbacker _feedbacker;
    
        public bool RemoveFlag {get => _removeFlag; set => _removeFlag = value; }

        public Feedback(Feedbacker feedbacker)
        {
            _feedbacker = feedbacker;
        }

        public virtual void Fire()
        {
            Debug.Log("Fired parent feedback class");
        }
    }
}
