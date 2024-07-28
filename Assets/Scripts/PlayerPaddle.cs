using UnityEngine;

// PlayerPaddle Class
public class PlayerPaddle : Paddle
{
    private void Start()
    {
        SetMovementStrategy(new PlayerMovementStrategy());
    }
}