using UnityEngine;

namespace Feedbacker
{
    public class AnimationFeedback : Feedback
    {
        [SerializeField] private Animation _animation;
        
        public AnimationFeedback(Feedbacker feedbacker) : base(feedbacker)
        {
            
        }

        public override void Play()
        {
            _animation.Play();
        }
    }

}
