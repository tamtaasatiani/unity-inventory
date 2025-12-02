using UnityEngine;

namespace Feedbacker
{
    [System.Serializable]
    public class SoundFeedback : Feedback
    {
        [SerializeField] private string testField;
            
        public override void Fire()
        {
            Debug.Log("Fired sound feedback class");
            //_audioSource.Play();
        }
    }
}
