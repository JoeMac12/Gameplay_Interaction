using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CheckForRequiredItems())
            {
                gameManager.TriggerLoseMenu(); // Really it's trigger win but this still works and im lazy
            }
            else
            {
                Debug.Log("You don't have all the required items!");
            }
        }
    }

    private bool CheckForRequiredItems()
    {
        Inventory inventory = Inventory.instance;
        return inventory.HasItem("PurpleCoin") &&
               inventory.HasItem("YellowCoin") &&
               inventory.HasItem("RedCoin") &&
               inventory.HasItem("GreenCoin") &&
               inventory.HasItem("BlueCoin");
    }
}
