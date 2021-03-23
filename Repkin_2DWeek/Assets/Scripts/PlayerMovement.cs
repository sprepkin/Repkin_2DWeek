﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rB2D;

    public float runSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int levelMask = LayerMask.GetMask("Level");

            if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.down, .01f, levelMask))
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        //Run left and right
        float horizontalInput = Input.GetAxis("Horizontal");

        rB2D.velocity = new Vector2(horizontalInput * runSpeed * Time.deltaTime, rB2D.velocity.y);
    }

    void Jump()
    {
        rB2D.velocity = new Vector2(rB2D.velocity.x, jumpForce);
    }
}
