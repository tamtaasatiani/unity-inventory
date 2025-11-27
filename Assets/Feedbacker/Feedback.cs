public class Feedback
{
    protected Feedbacker _feedbacker;

    public Feedback(Feedbacker feedbacker)
    {
        _feedbacker = feedbacker;
    }
    
    public virtual void Fire() {}
}