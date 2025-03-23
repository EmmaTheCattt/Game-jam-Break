using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player attributes
    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;

    // Collider stuff
    [Header("Layers Interactions")]
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private SpriteRenderer SR;
    private ParticleSystem PS;
    private float horizontalInput;

    
    // Executes on startup
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        PS = GetComponentInChildren<ParticleSystem>();
        PS.enableEmission = false;
    }
    
    // Updates every frame
    private void Update()
    {
        // Horizontal and vertical movement according to input
        horizontalInput = Input.GetAxis("Horizontal");

        // Flip player according to movement direction
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
            SR.flipX = false;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            SR.flipX = true;
        }

        // Check Jump input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        // Adjust Jump height if key isnt held down anymore
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }

        // Reset gravity
        rb.gravityScale = gravity;

        // Horizontal movement is performed here
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (isGrounded())
        {
            coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
            jumpCounter = extraJumps; //Reset jump counter to extra jump value
        }
        else
        {
            coyoteCounter -= Time.deltaTime; 
        }
        
    }

    // Player functions
    private void Jump()
    {   
        // Can you still jump???
        if (coyoteCounter <= 0 && jumpCounter <= 0)
        {
            return;
        }

        
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        else
        {
            // If not on ground and coyoteCounter ran out, do a normal jump instead of an extra jump
            if (coyoteCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            else 
            {
                if (jumpCounter > 0) // Check if we still have jumps left to do
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                    jumpCounter--;
                    PS.enableEmission = true;
                    Invoke("Particles_mouse_off", 0.025f);
                }
            }
            // Reset coyoteCounter
            coyoteCounter = 0;
        }

        
        
    }

    

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void Particles_mouse_off()
    {
        PS.enableEmission = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Debug.Log("Death");
        }
    }


}