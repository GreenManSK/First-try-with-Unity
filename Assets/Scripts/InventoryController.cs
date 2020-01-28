using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Dictionary<DropType, int> inventory;

    private void Start()
    {
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
}