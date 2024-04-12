using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCapacity = 10;
    public List<GameObject> items = new List<GameObject>();
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public bool AddItem(GameObject item)
    {
        if (items.Count >= maxCapacity)
        {
            Debug.Log("Inventory is full!");
            return false;
        }
        items.Add(item);
        Debug.Log(item.name + " added to inventory.");
        return true;
    }

    public bool HasItem(string itemName)
    {
        foreach (GameObject item in items)
        {
            if (item.name == itemName)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == itemName)
            {
                items.RemoveAt(i);
                Debug.Log(itemName + " removed from inventory.");
                return;
            }
        }
        Debug.Log("Item not found in inventory: " + itemName);
    }
}
