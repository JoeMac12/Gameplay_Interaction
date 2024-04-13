using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public string endSceneName = "End";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (CheckForRequiredItems())
            {
                SceneManager.LoadScene(endSceneName);
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
