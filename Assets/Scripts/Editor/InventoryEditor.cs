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
        
        itemSelectedFromRemoveList = _inventory?.GetItems()[0] != null ? _inventory.GetItems()[0] : ScriptableObject.CreateInstance<Item>();
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
            
            EditorGUILayout.LabelField(item.Data.Name);
        }
    }

    private void AddItemUI()
    {
        EditorGUILayout.LabelField("Add Item", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_itemToAddProperty);
        Item itemToAdd = _itemToAddProperty.objectReferenceValue as Item;
        //Item itemToAdd = ScriptableObject.CreateInstance<Item>();

        if (GUILayout.Button("Confirm") && itemToAdd != null)
        {
            _inventory.AddItem(_itemToAddProperty.objectReferenceValue as Item);
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
        
        string buttonText = !_inventory.IsEmpty() ? itemSelectedFromRemoveList.Data.Name : "Select Item";
        if (!GUILayout.Button(buttonText)) return;
        if (_inventory.GetItems().Count == 0) return;
        
        foreach (Item item in _inventory.GetItems())
            {
                if (item == null) return;
                if (item.Data == null) return;
                removeItemMenu.AddItem(new GUIContent(item.Data.Name), itemSelectedFromRemoveList.Equals(item), () =>
                {
                    itemSelectedFromRemoveList = item;
                });
            }
            
        removeItemMenu.ShowAsContext();
    }
}
