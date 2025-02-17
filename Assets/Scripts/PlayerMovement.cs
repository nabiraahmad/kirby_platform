using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float speed = 5f;
    public float jumpForce = 10f;
    private float moveInput;
    private bool isGrounded;

    // Components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    // Ground Check
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f; // Increased radius for detection
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

void Update()
{
    // Get Horizontal input
    moveInput = Input.GetAxis("Horizontal");

    // Move Kirby - Update Rigidbody2D velocity directly
    rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

    // If Animator is causing issues, disable it temporarily during movement
    this.GetComponent<Animator>().enabled = false;  // Disable Animator temporarily

    // Flip Kirby's sprite depending on direction
    if (moveInput > 0)
        spriteRenderer.flipX = false;
    else if (moveInput < 0)
        spriteRenderer.flipX = true;

    // Enable Animator again for the jumping state
    if (isGrounded)
    {
        this.GetComponent<Animator>().enabled = true;  // Re-enable Animator when grounded
        anim.SetFloat("Speed", Mathf.Abs(moveInput)); // Set animation speed
    }

    // Jumping Logic
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        anim.SetBool("isJumping", true);
        isGrounded = false;
    }
}

void FixedUpdate()
{
    // Ground check logic
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    if (isGrounded)
    {
        anim.SetBool("isJumping", false);
    }
}
}
