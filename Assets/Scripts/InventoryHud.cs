using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryHud : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
    }

    void Update()
    {
        UpdateInventoryText();
    }

    void UpdateInventoryText()
    {
        inventoryText.text = "Inventory:\n";
        foreach (GameObject item in inventory.items)
        {
            inventoryText.text += item.name + "\n";
        }
    }
}
