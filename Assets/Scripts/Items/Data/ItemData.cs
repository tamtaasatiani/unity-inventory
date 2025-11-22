using UnityEditor;
using UnityEngine;

namespace Items
{
    public class ItemData : ScriptableObject
    {
        [SerializeField] private NameData data;
        
        public NameData NameData => data;
    }
}
