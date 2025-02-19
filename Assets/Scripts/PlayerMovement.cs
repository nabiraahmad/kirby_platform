using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private float moveInput;
    private bool isGrounded;
    private AudioSource audioSource;
    public AudioClip deathSound;

    private Rigidbody2D rb;
    private Animator anim;  
    private SpriteRenderer spriteRenderer;  
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f; 
    public LayerMask groundLayer;

    public Transform loseZoneCheck; // This is where we will check if Kirby falls off
    public float fallThreshold = -10f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        anim = transform.Find("kirbySprite").GetComponent<Animator>();
        spriteRenderer = transform.Find("kirbySprite").GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

          if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Space key was pressed!");
    }
    
    if (Input.GetKey(KeyCode.Space))
    {
        Debug.Log("Space key is being held down!");
    }
        moveInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;


        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                Debug.Log("Jumping..."); 
                anim.SetBool("isJumping", true); 
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
                isGrounded = false;  
            }
        
        if (transform.position.y < fallThreshold)
        {
            // Play death sound
            if (deathSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSound); // Play the death sound once
            }
        }
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded);
        Debug.Log("Velocity: " + rb.linearVelocity);
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, Color.red, 0.1f);

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);  
        }
    }
}
