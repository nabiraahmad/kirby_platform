using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private float moveInput;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;  
    private SpriteRenderer spriteRenderer;  
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = transform.Find("kirbySprite").GetComponent<Animator>();
        spriteRenderer = transform.Find("kirbySprite").GetComponent<SpriteRenderer>();
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
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded);
        Debug.Log("Velocity: " + rb.linearVelocity);

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);  
        }
    }
}
