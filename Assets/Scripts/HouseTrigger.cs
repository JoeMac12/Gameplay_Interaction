using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseLevelTrigger : MonoBehaviour
{
    [SerializeField] private string houseLevelSceneName = "HouseLevel"; // Set the correct scene name in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(houseLevelSceneName);
        }
    }
}

