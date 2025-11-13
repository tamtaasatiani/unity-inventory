using Items;
using UnityEngine;

[CreateAssetMenu(menuName = "Libraries/Item Library")]
public class ItemLibrary : ScriptableObject
{
    [SerializeField] Item[] items;
}
