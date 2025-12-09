using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

namespace Feedbacker
{
    [AddComponentMenu("Feedbacker/Feedbacker")]
    public class Feedbacker : MonoBehaviour
    {

        [SerializeReference] private List<Feedback> feedbacks =  new List<Feedback>();

        public List<Feedback> Feedbacks {get {return feedbacks;} private set { feedbacks = value; } }
    
        public async UniTask Play(CancellationToken cancellationToken = default, Action callback = null)
        {
            List<UniTask> tasks = ListPool<UniTask>.Get();
            
            foreach (var feedback in feedbacks)
            {
                tasks.Add(feedback.Play(cancellationToken));
            }

            await UniTask.WhenAll(tasks);
            callback?.Invoke();
        }
    
        public bool IsEmpty()
        {
            if (feedbacks.Count == 0) return true;
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
            return feedbacks;
        }

        //public List<int> ReturnFlaggedFeedbacks()
        //{
        //    return _feedbacks.Where(feedback => feedback.RemoveFlag == true).ToList().ForEach(feedback => RemoveFeedback(feedback));
        //}

        public void RemoveAllFeedbacks()
        {
            feedbacks.Clear();
        }
    }

}
