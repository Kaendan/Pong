using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class : Used by ControllerPlayer and ControllerAI - Controls a paddle
public abstract class Controller : MonoBehaviour
{
    // the paddle's Speed
    public float _Speed = 5;
    // Axis used to move the paddle : Only used for debugging on computer
    public string _Axis = "Horizontal";
    // Whether the paddle is at top or the bottom
    public bool _Top = false;

    public Collider2D _Collider;

    // The Y direction of the paddle
    protected int _DirectionY;
    // Size of the collider bounds
    protected Vector2 _Size;

    // Paddle bounds : Used to restrain movements
    protected float _MinBound = -2.2f;
    protected float _MaxBound = 2.2f;

    void Start()
    {
        if (_Top) {
            _DirectionY = -1;
        } else {
            _DirectionY = 1;
        }

        _Size = _Collider.bounds.size;
    }

    void FixedUpdate()
    { 
        // Manages inputs
        float x = _Speed * ManageInputs() * Time.deltaTime;
        // Moves the paddle
        transform.Translate(x, 0, 0);

        // Prevents the paddle from going out of its bounds
        if (transform.position.x > _MaxBound) {
            transform.position = new Vector3(_MaxBound, transform.position.y, 0);
        } else if (transform.position.x < _MinBound) {
            transform.position = new Vector3(_MinBound, transform.position.y, 0);
        }
    }

    public Vector2 GetSize()
    {
        return _Size;
    }

    public int GetDirectionY()
    {
        return _DirectionY;
    }

    // Manages inputs and returns the new X position
    public abstract float ManageInputs();

}
