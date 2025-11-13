using UnityEditor;
using UnityEngine;

namespace Items
{
    public class Item : ScriptableObject
    {
        [SerializeField] private ItemData data;
    }
}
