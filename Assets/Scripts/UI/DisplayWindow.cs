using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWindow : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Feedbacker.Feedbacker feedbacks;
    
    private CancellationTokenSource _cancellationTokenSource;

    public void Initialize(Sprite image, string itemName, string description)
    {
        this.image.sprite = image;
        this.itemName.text = itemName;
        this.description.text = description;
    }

    public void DropCLicked()
    {
        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
            destroyCancellationToken,
            Application.exitCancellationToken);
        feedbacks.Play(_cancellationTokenSource.Token);
    }
    
    public void ShowWindow()
    {
        window.SetActive(true);
    }
    
    public void HideWindow()
    {
        window.SetActive(false);
    }
}
