using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls a paddle with a player's inputs
public class ControllerPlayer : Controller
{
    // Manages inputs and returns the new X position
    public override float ManageInputs()
    {
        float x = Input.GetAxisRaw(_Axis);

        Vector2 pos = Vector2.zero;
        for (int i = 0; i < Input.touchCount; i++) {
            pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            // If there is a touch in the "paddle zone"
            if (_Top && pos.y > 0 || !_Top && pos.y < 0) {
                if (pos.x < 0) { // Moves it to the left if the left side of the screen is touched
                    x = -1;
                } else { // Moves it to the right if the right side of the screen is touched
                    x = 1;
                }
                break;
            }
        }

        return x;
    }
}
