using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Dictionary<DropType, int> inventory;

    private bool _isColliding;
    private void Start()
    {
        inventory = new Dictionary<DropType, int>();
        var types = Enum.GetValues(typeof(DropType)).Cast<DropType>();
        foreach (var type in types)
        {
            inventory.Add(type, 0);
        }
    }

    public int Get(DropType type)
    {
        return inventory[type];
    }

    public void Add(DropType type, int volume)
    {
        inventory[type] += volume;
    }

    public bool Remove(DropType type, int volume)
    {
        if (inventory[type] < volume)
            return false;
        inventory[type] -= volume;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(Tags.Drop)) return;
        if(_isColliding) return;
        _isColliding = true;
        var drop = other.gameObject.GetComponent<DropItemController>();
        Add(drop.type, drop.quantity);
        drop.Collect();
        _isColliding = false;
    }
}