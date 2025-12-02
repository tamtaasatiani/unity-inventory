using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Feedbacker.Feedbacker _feedbacks;

    public void OnClick()
    {
        _feedbacks.Play();
    }
}
