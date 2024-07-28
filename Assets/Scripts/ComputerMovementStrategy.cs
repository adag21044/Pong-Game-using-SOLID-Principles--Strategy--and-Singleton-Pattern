using UnityEngine;
// ComputerMovementStrategy Class
public class ComputerMovementStrategy : IPaddleMovementStrategy
{
    private Rigidbody2D ball;

    public ComputerMovementStrategy(Rigidbody2D ball)
    {
        this.ball = ball;
    }

    public void Move(Rigidbody2D rb, float speed)
    {
        if (ball.velocity.x > 0f)
        {
            if (ball.position.y > rb.position.y)
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < rb.position.y)
            {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            if (rb.position.y > 0f)
            {
                rb.AddForce(Vector2.down * speed);
            }
            else if (rb.position.y < 0f)
            {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }
}