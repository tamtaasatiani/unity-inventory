using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;

    public void Initialize(Sprite image, string name, string description)
    {
        _image.sprite = image;
        _name.text = name;
        _description.text = description;
        
        //float height = _image.CalculateLayoutInputVertical();
        //_image.SetNativeSize();
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
