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
        
        public void Initialize(Item item)
        {
            icon.sprite = item.Data.Icon;
            displayName.text = item.Data.DisplayName;
        }
    }
}
