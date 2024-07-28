﻿using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Paddle : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed = 8f;
    public bool useDynamicBounce = false;
    protected IPaddleMovementStrategy movementStrategy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovementStrategy(IPaddleMovementStrategy strategy)
    {
        movementStrategy = strategy;
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = new Vector2(rb.position.x, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useDynamicBounce && collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ball = collision.rigidbody;
            Collider2D paddle = collision.otherCollider;

            Vector2 ballDirection = ball.velocity.normalized;
            Vector2 contactDistance = ball.transform.position - paddle.bounds.center;
            Vector2 surfaceNormal = collision.GetContact(0).normal;
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, surfaceNormal);

            float maxBounceAngle = 75f;
            float bounceAngle = contactDistance.y / paddle.bounds.size.y * maxBounceAngle;
            ballDirection = Quaternion.AngleAxis(bounceAngle, rotationAxis) * ballDirection;

            ball.velocity = ballDirection * ball.velocity.magnitude;
        }
    }

    private void FixedUpdate()
    {
        movementStrategy?.Move(rb, speed);
    }
}