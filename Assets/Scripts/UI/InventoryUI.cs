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

        private List<GameObject> _itemViews = new List<GameObject>();

        private void Start()
        {
            UpdateInventory();
            Inventory.Instance.ItemAdded += UpdateInventory;
            Inventory.Instance.ItemRemoved += UpdateInventory;
        }

        private void OnDestroy()
        {
            Inventory.Instance.ItemAdded -= UpdateInventory;
            Inventory.Instance.ItemRemoved -= UpdateInventory;
        }
        
        private void UpdateInventory()
        {
            WipeViews();
            
            if (Inventory.Instance.GetItems().Count == 0) return;
            
            foreach (Item item in Inventory.Instance.GetItems())
            {
                var itemViewObj = Instantiate(itemViewPrefab, scrollViewContent.transform);
                var itemView = itemViewObj.GetComponent<ItemView>();
                _itemViews.Add(itemViewObj);
                itemView.Initialize(item);
            }
        }

        private void WipeViews()
        {
            if (_itemViews.Count == 0) return;
            
            foreach (GameObject view in _itemViews)
            {
                Destroy(view);
            }
        }
    }
}
