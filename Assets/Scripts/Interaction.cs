using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E; // Default use key

    private InteractableObject currentItem;

    private void OnTriggerEnter2D(Collider2D other) // On item enter range
    {
        InteractableObject interactable = other.GetComponent<InteractableObject>();
        if (interactable != null)
        {
            currentItem = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        InteractableObject interactable = other.GetComponent<InteractableObject>(); // Check if it has the script
        if (interactable == currentItem)
        {
            currentItem = null;
        }
    }

    void Update() // Interact with a valid item
    {
        if (Input.GetKeyDown(interactKey) && currentItem != null)
        {
            currentItem.Interact();
        }
    }
}
