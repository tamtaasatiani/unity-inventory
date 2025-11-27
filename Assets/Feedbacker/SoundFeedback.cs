using UnityEngine;

public class SoundFeedback : Feedback
{
    private AudioSource _audioSource;
    private AudioClip _audioClip;

    public SoundFeedback(Feedbacker feedbacker) : base(feedbacker)
    {
        _feedbacker = feedbacker;
    }
    
    public override void Fire()
    {
        _audioSource.Play();
    }
}