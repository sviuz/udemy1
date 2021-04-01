using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float enemySpeed = 1f;
    [SerializeField] private float timeToWait = 5f;

    private Rigidbody2D rd;
    private Vector2 leftPosition;
    private Vector2 rightPosition;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        leftPosition = transform.position;
        rightPosition = leftPosition + Vector2.right * walkDistance;
    }

    private void FixedUpdate()
    {
        rd.MovePosition((Vector2)transform.position + Vector2.right * enemySpeed * Time.fixedDeltaTime );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftPosition, rightPosition);
    }
}
