using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public enum InteractionType { Pickup, Info }
    [SerializeField] private InteractionType interactionType;

    [Header("Pickup Settings")]
    [SerializeField] private string pickupName = "Item";

    [Header("Info Settings")]
    [SerializeField] private string infoText = "Uhhhhh something something";
    [SerializeField] private float infoDisplayTime = 3f;

    [SerializeField] private TextMeshProUGUI playerText;


    public void Interact() // Switch statement is MUCH easier to use
    {
        switch (interactionType)
        {
            case InteractionType.Pickup:
                HandlePickup();
                break;
            case InteractionType.Info:
                HandleInfo();
                break;
            default:
                Debug.LogWarning("Can't do anything with this"); // Fail safe or just default
                break;
        }
    }

    private void HandlePickup() // Handle picking up a object that can be picked up
    {
        Debug.Log("Picked up: " + pickupName);
        Destroy(gameObject);
    }

    private void HandleInfo() // Handle displaying the text
    {
        if(playerText != null)
        {
            playerText.text = infoText;
            playerText.gameObject.SetActive(true); // Set text active

            StartCoroutine(HideText());
        }
    }

    private IEnumerator HideText() // Hide the text after some time
    {
        yield return new WaitForSeconds(infoDisplayTime);
        playerText.gameObject.SetActive(false); // Disable it
    }
}
