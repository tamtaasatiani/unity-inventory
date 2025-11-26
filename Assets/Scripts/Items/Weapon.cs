using UnityEditor;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    public class WeaponData : ItemData
    {
        [SerializeField] private StatData weaponData;
    }
}
