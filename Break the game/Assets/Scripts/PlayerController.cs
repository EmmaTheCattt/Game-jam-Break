using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float coyoteTime;
    private bool canDoubleJump;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    
    // Executes on startup
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    // Updates every frame
    private void Update()
    {
        // Horizontal and vertical movement according to input
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);


        // Check Jump input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Vertical") > 0.3)
        {
            Jump();
        }
    }

    // Player functions
    private void Jump()
    {   
        if (isGrounded())
        {
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}

