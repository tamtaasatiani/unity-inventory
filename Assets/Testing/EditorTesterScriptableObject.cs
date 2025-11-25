using Items;
using UI;
using UnityEngine;

public class EditorTesterScriptableObject : MonoBehaviour
{
    [SerializeField] private ItemData sword;
    
    [SerializeField] private ItemView itemView;

    private void Awake()
    {
        itemView.Initialize(new Item(sword, 10));
    }
}
