using UnityEngine;

// PlayerMovementStrategy Class
public class PlayerMovementStrategy : IPaddleMovementStrategy
{
    public void Move(Rigidbody2D rb, float speed)
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        rb.AddForce(direction * speed);
    }
}