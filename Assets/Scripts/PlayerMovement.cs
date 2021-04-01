using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    private FinishScript finish;
    private Rigidbody2D _rd;
    private LeverArm _leverArm;
    
    private float speedX = 5f;
    private float _direction;
    private const float SpeedMultiplier = 50f;

    private bool _isGround;
    private bool _isJump;
    private bool _isFacingRight;
    private bool isFinished = false;
    private bool isLeverArm;
    
    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishScript>();
        _leverArm = FindObjectOfType<LeverArm>(); 
    }

    void Update()
    {
        _direction = Input.GetAxis("Horizontal");
        anim.SetFloat("speedX", Math.Abs(_direction));
        
        if (Input.GetKey(KeyCode.W) && _isGround)
        {
            _isJump = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFinished)
            {
                finish.FinishLevel();
            }
            if (isLeverArm)
            {
                _leverArm.Activate();    
            }
        }
    }

    private void FixedUpdate()
    {
        _rd.velocity = new Vector2(_direction * speedX * SpeedMultiplier * Time.fixedDeltaTime, _rd.velocity.y);

        if (_direction>0 && _isFacingRight)
        {
            FlipPlayer();
        }
        else if(_direction<0 && !_isFacingRight)
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
        _isFacingRight = !_isFacingRight;
        var playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
     {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
        
     }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        LeverArm temp = other.GetComponent<LeverArm>();
        if (other.gameObject.CompareTag("Finish"))
        {
            isFinished = true;
        }
        if (temp)
        {
            isLeverArm = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LeverArm temp = other.GetComponent<LeverArm>();
        if (other.gameObject.CompareTag("Finish"))
        {
            isFinished = false;
        }
        if (temp)
        {
            isLeverArm = false;
        }
    }

    
}
