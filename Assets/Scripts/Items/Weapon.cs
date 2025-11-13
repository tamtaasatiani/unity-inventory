using UnityEditor;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [SerializeField] private WeaponData weaponData;
    }
}
