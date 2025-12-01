using UnityEngine;

namespace Feedbacker
{
    [System.Serializable]
    public class Feedback
    {
        
        protected bool _removeFlag = false;
        protected Feedbacker _feedbacker;
    
        public bool RemoveFlag {get => _removeFlag; set => _removeFlag = value; }

        public virtual void Fire()
        {
            Debug.Log("Fired parent feedback class");
        }
    }
}
