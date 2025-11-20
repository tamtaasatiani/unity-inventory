using System.Collections.Generic;
using Items;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject itemViewPrefab;
        
        [Header("UI Elements")]
        [SerializeField] private GameObject scrollViewContent;

        [SerializeField] private DisplayWindow displayWindow;

        private List<ItemView> _itemViews = new List<ItemView>();
        private ItemView _selectedView;

        private void Start()
        {
            Inventory.Instance.ItemAdded += AddView;
            Inventory.Instance.ItemRemoved += RemoveView;
        }

        private void OnDestroy()
        {
            Inventory.Instance.ItemAdded -= AddView;
            Inventory.Instance.ItemRemoved -= RemoveView;

            foreach (ItemView view in _itemViews)
            {
                view.ViewClicked -= HandleViewClicked;
            }
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
            displayWindow.HideWindow();
            _selectedView = null;
            
            ItemView destroyView = _itemViews.Find(itemView => itemView.Item == item);
            if (destroyView != null) Destroy(destroyView.gameObject);
        }

        private void HandleViewClicked(ItemView view)
        {
            if (_selectedView != null) _selectedView.HideBorder();
            _selectedView = view;
            _selectedView.ShowBorder();
            displayWindow.Initialize(view.Item.Data.Icon, view.Item.Data.DisplayName, view.Item.Data.Description);
            displayWindow.ShowWindow();
        }
    }
}
