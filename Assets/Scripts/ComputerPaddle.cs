using UnityEngine;
// ComputerPaddle Class
public class ComputerPaddle : Paddle
{
    [SerializeField]
    private Rigidbody2D ball;

    private void Start()
    {
        SetMovementStrategy(new ComputerMovementStrategy(ball));
    }
}