using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject itemViewPrefab;
        
        [Header("UI Elements")]
        [SerializeField] private GameObject scrollViewContent;
        [SerializeField] private DisplayWindow displayWindow;
        [SerializeField] private Button dropButton;

        private List<ItemView> _itemViews = new List<ItemView>();
        private ItemView _selectedView;

        private void Start()
        {
            Inventory.Instance.ItemAdded += AddView;
            Inventory.Instance.ItemRemoved += RemoveView;
            
            displayWindow.HandleDropButtonClicked += DropSelectedItem;
        }

        private void OnDestroy()
        {
            Inventory.Instance.ItemAdded -= AddView;
            Inventory.Instance.ItemRemoved -= RemoveView;

            foreach (ItemView view in _itemViews)
            {
                view.ViewClicked -= HandleViewClicked;
            }
            
            //if (dropButton != null) dropButton.onClick.AddListener(() => DropItem(_selectedView.Item));
            displayWindow.HandleDropButtonClicked -= DropSelectedItem;
        }

        private void AddView(Item item)
        {
            if (!Inventory.Instance.GetItems().Contains(item)) return;
            
            var itemViewObj = Instantiate(itemViewPrefab, scrollViewContent.transform);
            var itemView = itemViewObj.GetComponent<ItemView>();
            _itemViews.Add(itemView);
            itemView.Initialize(item);
            itemView.ViewClicked += HandleViewClicked;
        }

        private void RemoveView(Item item)
        {
            if (_selectedView != null && item == _selectedView.Item)
            {
                displayWindow.HideWindow();
                _selectedView.HideBorder();
                _selectedView = null;
            }
            
            ItemView destroyView = _itemViews.Find(itemView => itemView.Item == item);
            if (destroyView != null) Destroy(destroyView.gameObject);
        }

        private void HandleViewClicked(ItemView view)
        {
            if (_selectedView != null && _selectedView != view) _selectedView.HideBorder();
            _selectedView = view;
            displayWindow.Initialize(view.Item.Data.NameData.Icon, view.Item.Data.NameData.DisplayName, view.Item.Data.NameData.Description);
            displayWindow.ShowWindow();
        }

        private void DropSelectedItem()
        {
            Inventory.Instance.RemoveItem(_selectedView.Item);
        }
    }
}
