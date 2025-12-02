using UnityEditor;
using UnityEngine;

namespace Feedbacker
{
    public class AnimationFeedback : Feedback
    {
        [SerializeField] private GameObject target;
        [SerializeField] private AnimationClip clip;
        
        private Animator _animator;
        
        public AnimationFeedback(Feedbacker feedbacker) : base(feedbacker)
        {
            if (target == null) return;
        }

        public override void Play()
        {
            if (target == null)
            {
                Debug.LogWarning("No object selected");
                return;
            }

            if (!AnimatorAvailable())
            {
                Debug.LogWarning("Target requires to have an animator");
                return;
            }
            
            _animator.Play(clip.name);
        }
        
        private bool AnimatorAvailable()
        {
            if (_animator != null)
                return true;
            
            if (!target.TryGetComponent(out Animator anim))
                return false;

            _animator = anim;
            return true;
        }
    }

}
