using Cysharp.Threading.Tasks;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Feedbacker.Feedbacker _feedbacks;

    public void OnClick()
    {
        _feedbacks.Play(() =>
        {
            Destroy(gameObject);
        }).Forget();
    }
}
