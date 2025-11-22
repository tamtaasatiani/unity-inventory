using System;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    
    [SerializeField] private ItemData item;
    
    private List<Item> _items = new List<Item>();

    public event Action<Item> ItemAdded;
    public event Action<Item> ItemRemoved;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy (Instance);
        }

        Instance = this;
    }

    public void AddItem(Item item)
    {
        //if (ContainsItem(item)) return;
        _items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(item);
    }

    public bool ContainsItem(Item item)
    {
        return _items.Contains(item);
    }

    public bool IsEmpty()
    {
        if  (_items.Count == 0) return true;
        return false;
    }
    
    public List<Item> GetItems()
    {
        return _items;
    }

    public int GetItemCount()
    {
        return _items.Count;
    }
}
