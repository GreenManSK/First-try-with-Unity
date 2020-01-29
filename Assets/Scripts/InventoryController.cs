using System.Collections.Generic;
using Constants;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Dictionary<DropType, int> inventory = new Dictionary<DropType, int>();

    public delegate void Change(DropType type, int newVolume);
    public event Change Changed;
    
    private bool _isColliding;

    public int Get(DropType type)
    {
        return inventory.ContainsKey(type) ? inventory[type] : 0;
    }

    public void Add(DropType type, int volume)
    {
        if (!inventory.ContainsKey(type))
            inventory[type] = 0;
        inventory[type] += volume;
        Changed?.Invoke(type, inventory[type]);
    }

    public bool Remove(DropType type, int volume)
    {
        if (Get(type) < volume)
            return false;
        inventory[type] -= volume;
        Changed?.Invoke(type, inventory[type]);
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(Tags.Drop)) return;
        if (_isColliding) return;
        var drop = other.gameObject.GetComponent<DropItemController>();
        if (drop.isCollected()) return;
        
        _isColliding = true;
        Add(drop.type, drop.quantity);
        drop.Collect();
        _isColliding = false;
    }
}