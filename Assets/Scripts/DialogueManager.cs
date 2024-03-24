using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour // Dialogue Manager
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public float typingSpeed = 0.02f;

    private Queue<string> sentences;
    private bool isDialogueActive = false;

    void Start()
    {
        sentences = new Queue<string>(); // Create new sentence
    }

    public void StartDialogue(string[] dialogueLines) // Start Dialogue
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() // Show next sentence
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) // Get text and type it
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue() // End and hide the dialogue
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }

    void Update() // Space to show next sentence
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            DisplayNextSentence();
        }
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
