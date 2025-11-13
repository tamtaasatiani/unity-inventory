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
        //itemSelectedFromRemoveList = _inventory.GetItems()[0];
        
        _itemToAddProperty = serializedObject.FindProperty("item");
        
        _inventory = target as Inventory;
        if (_inventory == null)
        {
            Debug.LogError("InventoryEditor only works with Inventory");
        }
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        AddItemUI();
        RemoveItemUI();
        
        serializedObject.ApplyModifiedProperties();
    }

    private void AddItemUI()
    {
        EditorGUILayout.LabelField("Add Item", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_itemToAddProperty);
        Item itemToAdd = _itemToAddProperty.objectReferenceValue as Item;

        if (GUILayout.Button("Confirm") && itemToAdd != null)
        {
            _inventory.AddItem(_itemToAddProperty.objectReferenceValue as Item);
        }
    }

    private void RemoveItemUI()
    {
        EditorGUILayout.LabelField("Remove Item", EditorStyles.boldLabel);
        GenericMenu removeItemMenu = new GenericMenu();

        if (!GUILayout.Button("Select Item")) return;
        if (_inventory.GetItems().Count == 0) return;
        
        foreach (Item item in _inventory.GetItems())
        {
            if (item == null) return;
            removeItemMenu.AddItem(new GUIContent(item.Data.Name), itemSelectedFromRemoveList.Equals(item), () =>
            {
                itemSelectedFromRemoveList = item;
            });
        }
        
        removeItemMenu.ShowAsContext();
    }
}
