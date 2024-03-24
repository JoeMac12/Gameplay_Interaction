using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{
    [Header("Input settings:")]
    public float speedMultiplier = 5.0f;

    [Space]
    [Header("Character Stats:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Animator animator;

    public DialogueManager dialogueManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
	void Update()
	{
		if (dialogueManager != null && !dialogueManager.IsDialogueActive()) // Check if dialogue is active
		{
			movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
			movementDirection.Normalize();

			//Sets the idle to the last direction moved
			if (Input.GetAxis("Horizontal") >= 0.1f || Input.GetAxis("Horizontal") <= -0.1f || Input.GetAxis("Vertical") >= 0.1f || Input.GetAxis("Vertical") <= -0.1f)
			{
				animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
				animator.SetFloat("LastMoveY", Input.GetAxis("Vertical"));
			}
		}
		else
		{
			movementSpeed = 0;
			rb.velocity = Vector2.zero;
		}
		Move();
		Animate();
	}

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * speedMultiplier;
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementSpeed);
    }

}
