using UnityEditor;
using UnityEngine;

namespace Item
{
    public class Item : ScriptableObject
    {
        [SerializeField] private ItemData data;
    }
}
