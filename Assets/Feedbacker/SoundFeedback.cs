using UnityEngine;

namespace Feedbacker
{
    public class SoundFeedback : Feedback
    {
        [SerializeField] private GameObject testField;
            
        public SoundFeedback(Feedbacker feedbacker) : base(feedbacker)
        {
            _feedbacker = feedbacker;
        }
    
        public override void Fire()
        {
            Debug.Log("Fired sound feedback class");
            //_audioSource.Play();
        }
    }
}
