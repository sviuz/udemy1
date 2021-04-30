    using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float enemySpeed = 1f;
    [SerializeField] private float timeToWait = 5f;

    private Rigidbody2D _rd;
    private Vector2 _leftPosition;
    private Vector2 _rightPosition;

    private bool _isOutOfLeftBorder;
    private bool _isOutOfRightBorder;
    private bool _isFacingRight;
    private bool _isWaiting = true;
    
    private void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
        _leftPosition = transform.position;
        _rightPosition = _leftPosition + Vector2.right * walkDistance;
    }


    private void Update()
    {
        var position = transform.position;
        _isOutOfRightBorder = _isFacingRight && position.x >= _rightPosition.x;
        _isOutOfLeftBorder = !_isFacingRight && position.x >= _leftPosition.x;

        if (_isOutOfLeftBorder || _isOutOfRightBorder)
        {
            _isWaiting = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (!_isWaiting)
        {
            _rd.MovePosition((Vector2)transform.position + Vector2.right * enemySpeed * Time.fixedDeltaTime );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftPosition, _rightPosition);
    }
}
