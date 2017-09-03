using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Ball's speed
    public float _Speed = 3f;
    // Maximum speed
    public float _MaxSpeed = 9f;
    // Sound played when a Paddle is hit
    public AudioClip _PaddleSound;
    // Sound played when a Wall is hit
    public AudioClip _WallSound;

    public AudioSource _AudioSource;
    public Collider2D _Collider;
    public Rigidbody2D _Body;
    public GameObject _Particles;
    public TrailRenderer _Trail;

    // Size of the collider bounds
    private Vector2 _Size;
    // The true velocity of the ball before it's modified by Unity's physic
    private Vector2 _TrueVelocity = new Vector2(0, 0);

    void Start()
    {
        _Size = _Collider.bounds.size;
    }

    public Vector2 GetSize()
    {
        return _Size;
    }

    public float GetSpeed()
    {
        return _Speed;
    }

    public void SetSpeed(float speed)
    {
        // Only set the speed if it's not greater than the maximum speed
        if (speed <= _MaxSpeed) {
            _Speed = speed;
        }
    }

    public void SetVelocity(Vector2 direction)
    {
        _TrueVelocity = direction * _Speed;
        _Body.velocity = _TrueVelocity;
    }

    public void SetDirection(Vector2 direction)
    {
        // Change the velocity x and y signs depending on the given direction
        Vector2 newDirection = _Body.velocity;
        newDirection.x = Mathf.Abs(newDirection.x) * direction.x;
        newDirection.y = Mathf.Abs(newDirection.y) * direction.y;

        _Body.velocity = newDirection;
    }

    public Vector2 GetVelocity()
    {
        return _Body.velocity;
    }

    public Vector2 GetTrueVelocity()
    {
        return _TrueVelocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Paddle") { // if a paddle is hit
            // Play sound
            _AudioSource.PlayOneShot(_PaddleSound);

            // Particle effect
            Instantiate(_Particles, transform.position, Quaternion.identity);

            Controller paddle = other.gameObject.GetComponent<Controller>();
            float x = (transform.position.x - other.transform.position.x) / paddle.GetSize().x;
            SetSpeed(GetSpeed() * 1.1f); // Increases the ball's speed
            SetVelocity(new Vector2(x, paddle.GetDirectionY()).normalized);
        } else if (other.gameObject.tag == "Wall") { // if a wall is hit
            // Play sound
            _AudioSource.PlayOneShot(_WallSound);

            // Particle effect
            Instantiate(_Particles, transform.position, Quaternion.identity);

            // If the paddle hits a Ball : Changes the ball's velocity depending on its X coordinate
            SetVelocity(new Vector2(_TrueVelocity.x * -1, _TrueVelocity.y).normalized);
        }
    }
}
