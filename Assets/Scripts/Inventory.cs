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
        if (items.Contains(item)) return;
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
