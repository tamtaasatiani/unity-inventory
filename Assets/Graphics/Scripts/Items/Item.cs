using UnityEngine;

namespace Items
{
    public class Item
    {
        private int _id;
        private string _uniqueName;
        protected ItemData _data;
        
        public ItemData Data {get => _data; private set => _data = value;}
        public int Id {get => _id; set => _id = value;}
        public string UniqueName {get => _uniqueName; set => _uniqueName = value;}
        
        public Item(ItemData data, int id)
        {
            _data = data;
            _id = id;
            _uniqueName = _data.name + id;
        }
    }
}

