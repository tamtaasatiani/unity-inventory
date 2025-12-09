using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Feedbacker.Feedbacker feedbacks;
    
    private CancellationTokenSource _cancellationTokenSource;

    public void OnClick()
    {
        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
            destroyCancellationToken,
            Application.exitCancellationToken);
        
        feedbacks.Play(_cancellationTokenSource.Token, () =>
        {
            Destroy(gameObject);
        }).Forget();
    }
}
