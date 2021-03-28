using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speedX = 5f;
    private Rigidbody2D _rd;
    private bool _isGround;
    private bool _isJump;
    private float _direction;
    private const float SpeedMultiplier = 50f;
    private bool isFacingRight;

    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _direction = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.W) && _isGround)
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        _rd.velocity = new Vector2(_direction * speedX * SpeedMultiplier * Time.fixedDeltaTime, _rd.velocity.y);

        if (_direction>=0 && !isFacingRight)
        {
            FlipPlayer();
        }
        else if(_direction<=0 && isFacingRight)
        {
            FlipPlayer();
        }
        
        if (_isJump)
        {
            _rd.AddForce(new Vector2(0,500f));
            _isGround = _isJump = false;
        }
    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        var playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
     {
        if (other.collider.CompareTag("Ground"))
        {
            _isGround = true;
        }
     }
}
