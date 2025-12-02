using UnityEngine;

namespace Feedbacker
{
    [System.Serializable]
    public class Feedback
    {
        public Feedback()
        {
            
        }
        
        public Feedback(Feedbacker feedbacker)
        {
            
        }
        
        public virtual void Play()
        {
            Debug.Log("Playing parent feedback class");
        }
    }
}
