using UnityEngine;

namespace Item
{
    [System.Serializable]
    public class ItemData
    {
        [SerializeField] private string name;
        
        [SerializeField] private string displayName;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;
    }

}
