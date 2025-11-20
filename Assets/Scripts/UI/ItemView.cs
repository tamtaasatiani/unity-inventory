using System;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI displayName;
        [SerializeField] private GameObject border;
        [SerializeField] private Button viewButton;
        
        private Item _item;
        
        public Item Item {get => _item; set => _item = value;}

        public Action<ItemView> ViewClicked;
        
        public void Initialize(Item item)
        {
            _item = item;
            icon.sprite = _item.Data.Icon;
            displayName.text = _item.Data.DisplayName;
            
            viewButton = GetComponentInChildren<Button>();
            viewButton.onClick.AddListener(() => ViewClicked?.Invoke(this));
        }

        public void ShowBorder()
        {
            border.SetActive(true);
        }

        public void HideBorder()
        {
            border.SetActive(false);
        }
    }
}
