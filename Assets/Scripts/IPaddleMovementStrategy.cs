using UnityEngine;

// IPaddleMovementStrategy Interface
public interface IPaddleMovementStrategy
{
    void Move(Rigidbody2D rb, float speed);
}