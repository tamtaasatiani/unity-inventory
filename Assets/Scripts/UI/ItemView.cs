using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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

        [SerializeField] private Feedbacker.Feedbacker feedbacks;
        
        private Item _item;
        private CancellationTokenSource _cancellationTokenSource;
        
        public Item Item {get => _item; set => _item = value;}

        public Action<ItemView> ViewClicked;
        
        public void Initialize(Item item)
        {
            _item = item;
            icon.sprite = _item.Data.NameData.Icon;
            displayName.text = _item.Data.NameData.DisplayName;
            viewButton = GetComponentInChildren<Button>();
            viewButton.onClick.AddListener(() => ViewClicked?.Invoke(this));
        }

        public void ViewClickedEffects()
        {
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
                destroyCancellationToken,
                Application.exitCancellationToken);
            feedbacks.Play(_cancellationTokenSource.Token).Forget();
            border.SetActive(true);
        }

        public void HideBorder()
        {
            border.SetActive(false);
        }
    }
}
