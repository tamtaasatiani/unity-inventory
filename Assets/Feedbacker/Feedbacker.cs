using System.Collections.Generic;
using UnityEngine;

public class Feedbacker : MonoBehaviour
{
    private List<Feedback> _feedbacks;

    public void Fire()
    {
        foreach (var feedback in _feedbacks)
        {
            feedback.Fire();
        }
    }
    
    private void AddFeedback(Feedback feedback)
    {
        _feedbacks.Add(feedback);
    }
    
    private void RemoveFeedback(Feedback feedback)
    {
        _feedbacks.Remove(feedback);
    }
}
