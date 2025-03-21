using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private bool grounded;
    
    // Executes on startup
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Updates every frame
    private void Update()
    {
        // Horizontal and vertical movement according to input
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        if ((Input.GetAxis("Vertical") > 0.3 || Input.GetButton("Jump")) && grounded)
        {
            Jump();
        }
        
        // Sprite update
        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}

