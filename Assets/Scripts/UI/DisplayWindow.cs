using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    
    private AspectRatioFitter _aspectRatioFitter;

    public void Initialize(Sprite image, string name, string description)
    {
        _image.sprite = image;
        _name.text = name;
        _description.text = description;
        
        _aspectRatioFitter = _image.GetComponent<AspectRatioFitter>();
        if (_aspectRatioFitter == null)
        {
            Debug.LogError("Aspect ratio fitter not found");
            return;
        }
        
        float aspectRatio = image.rect.width / image.rect.height;
        _aspectRatioFitter.aspectRatio = aspectRatio;
    }
    
    public void ShowWindow()
    {
        _window.SetActive(true);
    }
    
    public void HideWindow()
    {
        _window.SetActive(false);
    }
}
