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

        private int _id = 0;
        
        public string Name { get => name; private set => name = value; }
        public string DisplayName { get => displayName; private set => displayName = value; }
        public string Description { get => description; private set => description = value; }
        public Sprite Icon { get => icon; private set => icon = value; }
        public int Id { get => _id; set => _id = value; }

        public void InitializeInInventory(int newId, string newName)
        {
            _id = newId;
            name = newName;
        }
    }

    [System.Serializable]
    public class WeaponData
    {
        [SerializeField] private int damage;
    }
}
