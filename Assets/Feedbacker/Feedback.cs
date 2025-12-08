using Cysharp.Threading.Tasks;
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
        
        public virtual UniTask Play()
        {
            Debug.LogWarning("Playing parent feedback class");
            return UniTask.CompletedTask;
        }
    }
}
