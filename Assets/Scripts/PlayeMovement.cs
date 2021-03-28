using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeMovement : MonoBehaviour
{
    public float speedX = 5f;
    public Rigidbody2D rd;
    public bool isGround;
    public bool isJump;
    private float direction;
    private const float SpeedMultiplier = 50f; 

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        var deltaTime = Time.fixedDeltaTime;
        rd.velocity = new Vector2(direction * speedX * SpeedMultiplier * deltaTime, rd.velocity.y);
        
        if (isJump)
        {
            rd.AddForce(new Vector2(0,5000f));
            isGround = isJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
