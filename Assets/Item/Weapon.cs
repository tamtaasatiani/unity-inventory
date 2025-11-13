using UnityEditor;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [SerializeField] private int _damage;
    }

}
