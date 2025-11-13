using UnityEngine;

namespace Items
{
    [System.Serializable]
    public class ItemData
    {
        [SerializeField] private string name;
        
        [SerializeField] private string displayName;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;
    }

    [System.Serializable]
    public class WeaponData
    {
        [SerializeField] private int damage;
    }
}
