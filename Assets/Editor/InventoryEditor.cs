using Items;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    [SerializeField] private Item itemSelectedFromRemoveList;
    
    private Inventory _inventory;
    private SerializedProperty _itemToAddProperty;

    void OnEnable()
    {
        _itemToAddProperty = serializedObject.FindProperty("item");
        
        _inventory = target as Inventory;
        if (_inventory == null)
        {
            Debug.LogError("InventoryEditor only works with Inventory");
        }
        
        itemSelectedFromRemoveList = !_inventory.IsEmpty() ? _inventory.GetItems()[0] : new Item(ScriptableObject.CreateInstance<ItemData>(), 0);
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        ItemListUI();
        AddItemUI();
        GUILayout.BeginHorizontal();
        RemoveItemUI();
        GUILayout.EndHorizontal();
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void ItemListUI()
    {
        EditorGUILayout.LabelField("Items:", EditorStyles.boldLabel);
        
        if (_inventory.IsEmpty()) return;
        
        foreach (Item item in _inventory.GetItems())
        {
            if (item == null) return;
            
            EditorGUILayout.LabelField(item.UniqueName);
        }
    }

    private void AddItemUI()
    {
        EditorGUILayout.LabelField("Add Item", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_itemToAddProperty);
        ItemData data = _itemToAddProperty.objectReferenceValue as ItemData;
        //Item itemToAdd = ScriptableObject.CreateInstance<Item>();

        if (GUILayout.Button("Confirm") && data != null)
        {
            int id = _inventory.GetItemCount() + 1;
            _inventory.AddItem(new Item(data, id));
        }
    }

    private void RemoveItemUI()
    {
        EditorGUILayout.LabelField("Remove Item", EditorStyles.boldLabel);
        
        GenerateMenu();
        
        if (GUILayout.Button("Confirm") && itemSelectedFromRemoveList.Data != null)
            _inventory.RemoveItem(itemSelectedFromRemoveList);
        
    }
    
    private void GenerateMenu()
    {
        GenericMenu removeItemMenu = new GenericMenu();

        bool selectedItemHasName = (itemSelectedFromRemoveList.UniqueName != null && itemSelectedFromRemoveList.UniqueName != "0");
        string buttonText = selectedItemHasName ? itemSelectedFromRemoveList.UniqueName : "Select Item";
        if (!GUILayout.Button(buttonText)) return;
        if (_inventory.GetItems().Count == 0) return;
        
        foreach (Item item in _inventory.GetItems())
            {
                if (item == null) return;
                if (item.Data == null) return;
                removeItemMenu.AddItem(new GUIContent(item.UniqueName), itemSelectedFromRemoveList.Equals(item), () =>
                {
                    itemSelectedFromRemoveList = item;
                });
            }
            
        removeItemMenu.ShowAsContext();
    }
}
