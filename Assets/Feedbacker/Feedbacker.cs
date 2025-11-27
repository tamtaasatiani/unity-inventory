using System.Collections.Generic;
using UnityEngine;

public class Feedbacker : MonoBehaviour
{
    [SerializeField] private List<Feedback> _feedbacks =  new List<Feedback>();

    public List<Feedback> Feedbacks {get {return _feedbacks;} private set { _feedbacks = value; } }
    
    public void Fire()
    {
        foreach (var feedback in _feedbacks)
        {
            feedback.Fire();
        }
    }
    
    public bool IsEmpty()
    {
        if (_feedbacks.Count == 0) return true;
        return false;
    }

    public void AddFeedback(SoundFeedback feedback)
    {
        _feedbacks.Add(feedback);
    }
    
    public void AddFeedback(Feedback feedback)
    {
        _feedbacks.Add(feedback);
    }
    
    public void RemoveFeedback(Feedback feedback)
    {
        _feedbacks.Remove(feedback);
    }
}
