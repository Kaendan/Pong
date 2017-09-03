using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls a paddle with an AI's inputs
public class ControllerAI : Controller
{
    GameObject _Ball;
    Rigidbody2D _BallBody;

    public void SetBall(Ball ball)
    {
        _Ball = ball.gameObject;
        _BallBody = _Ball.GetComponent<Rigidbody2D>();
    }

    // Manages inputs and returns the new X position
    public override float ManageInputs()
    {
        float x = 0;

        if (_Ball != null) {
            // If the ball is going up
            if (_BallBody.velocity.y > 0) {
                // Follow the ball's position so that the paddle is able to hit the ball
                // I could have done that with raycast too. To guess where the ball will hit the paddle and plan to move the paddle there with a delay (so that it's not unbeatable)
                if (_Ball.transform.position.x > this.transform.position.x + _Size.x / 2) {
                    x = 1;
                } else if (_Ball.transform.position.x < this.transform.position.x - _Size.x / 2) {
                    x = -1;
                }

            }
        } else {
            // If there is no ball move the paddle to the center of screen
            if (0 > this.transform.position.x + 0.1f) { // 
                x = 1;
            } else if (0 < this.transform.position.x - 0.1f) {
                x = -1;
            }
        }

        return x;
    }
}
