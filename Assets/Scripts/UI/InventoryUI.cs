using Items;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject itemViewPrefab;
        
        [SerializeField] private GameObject scrollViewContent;

        private void Start()
        {
            ShowInventory();
        }
        
        private void ShowInventory()
        {
            foreach (Item item in Inventory.instance.GetItems())
            {
                var itemViewObj = Instantiate(itemViewPrefab, scrollViewContent.transform);
                var itemView = itemViewObj.GetComponent<ItemView>();
                itemView.Initialize(item);
            }
        }
    }
}
