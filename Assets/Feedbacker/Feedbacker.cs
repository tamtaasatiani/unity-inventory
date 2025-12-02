using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Feedbacker
{
    [AddComponentMenu("Feedbacker/Feedbacker")]
    public class Feedbacker : MonoBehaviour
    {
        [SerializeReference] private List<Feedback> _feedbacks =  new List<Feedback>();

        public List<Feedback> Feedbacks {get {return _feedbacks;} private set { _feedbacks = value; } }
    
        public void Play()
        {
            foreach (var feedback in _feedbacks)
            {
                feedback.Play();
            }
        }
    
        public bool IsEmpty()
        {
            if (_feedbacks.Count == 0) return true;
            return false;
        }

        /*
        public void AddSoundFeedback()
        {
            SoundFeedback newFeedback = new SoundFeedback(this);
            _feedbacks.Add(newFeedback);
            //EditorUtility.SetDirty(newFeedback);
        }
    
        public void AddFeedback(Feedback feedback)
        {
            _feedbacks.Add(feedback);
        }
    
        public void RemoveFeedback(Feedback feedback)
        {
            _feedbacks.Remove(feedback);
        }
        */

        public List<Feedback> GetFeedbacks()
        {
            return _feedbacks;
        }

        //public List<int> ReturnFlaggedFeedbacks()
        //{
        //    return _feedbacks.Where(feedback => feedback.RemoveFlag == true).ToList().ForEach(feedback => RemoveFeedback(feedback));
        //}

        public void RemoveAllFeedbacks()
        {
            _feedbacks.Clear();
        }
    }

}
