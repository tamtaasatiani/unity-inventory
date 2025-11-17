using System;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    
    [SerializeField] private Item item;
    
    private List<Item> _items = new List<Item>();

    public event Action ItemAdded;
    public event Action ItemRemoved;
    
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
        if (ContainsItem(item)) return;
        _items.Add(item);
        ItemAdded?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke();
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
}
