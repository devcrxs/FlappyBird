using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    Vector2 movement;
    
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveSpeed * movement * Time.fixedDeltaTime);
    }
}
