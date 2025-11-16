using System.Collections.Generic;
using UnityEngine;
using Items;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<Item> items = new List<Item>();
    
    [SerializeField] private Item item;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy (instance);
        }

        instance = this;
    }

    public void AddItem(Item item)
    {
        int newId = items.Count > 0 ? items[items.Count - 1].Data.Id + 1 : 0;
        string newName = item.Data.Name + newId;
        item.Data.InitializeInInventory(newId, newName);
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }

    public bool IsEmpty()
    {
        if  (items.Count == 0) return true;
        return false;
    }
    
    public List<Item> GetItems()
    {
        return items;
    }
}
