using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public enum InteractionType { Pickup, Info, Dialogue }
    [SerializeField] private InteractionType interactionType;

    [Header("Pickup Settings")]
    [SerializeField] private string pickupName = "Item";

    [Header("Info Settings")]
    [SerializeField] private string infoText = "Uhhhhh something something";
    [SerializeField] private float infoDisplayTime = 3f;

    [SerializeField] private TextMeshProUGUI playerText;

    [Header("Dialogue Settings")]
    public string[] dialogueLines;
    public string[] alternateDialogueLines;
    public string requiredItem;
    public GameObject itemToGive;
    [SerializeField] private DialogueManager dialogueManager;

    private bool alternateDialogueTriggered = false;
    private Collider2D interactionCollider;

    void Start()
    {
        interactionCollider = GetComponent<Collider2D>();
    }

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
            case InteractionType.Dialogue:
                HandleDialogue();
                break;
            default:
                Debug.LogWarning("Can't do anything with this"); // Fail safe or just default
                break;
        }
    }

    private void HandlePickup() // Handle picking up a object that can be picked up
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory.AddItem(gameObject))
        {
            Debug.Log("Picked up: " + pickupName);
            gameObject.SetActive(false);
        }
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

    private void HandleDialogue() // Handle dialogue
    {
        if (dialogueManager != null)
        {
            if (!string.IsNullOrEmpty(requiredItem) && Inventory.instance.HasItem(requiredItem) && !alternateDialogueTriggered)
            {
                Inventory.instance.RemoveItem(requiredItem);

                if (itemToGive != null)
                {
                    Inventory.instance.AddItem(itemToGive);
                }

                dialogueManager.StartDialogue(alternateDialogueLines);
                alternateDialogueTriggered = true;
                interactionCollider.enabled = false; // Disable the collider
            }
            else
            {
                dialogueManager.StartDialogue(dialogueLines);
            }
        }
    }

    private IEnumerator HideText() // Hide the text after some time
    {
        yield return new WaitForSeconds(infoDisplayTime);
        playerText.gameObject.SetActive(false); // Disable it
    }
}
