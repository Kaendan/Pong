using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Represents a goal. When it's hit by a ball, it destroys the ball
public class Goal : MonoBehaviour
{
    private int _Score = 0;
    // Current score
    private int _MaxScore = 5;
    // Score to win

    public string _Name;
    // Name displayed at victory
    public Text _ScoreText;
    // Text to display the score
    public GameManager _GameManager;
    public Text _VictoryText;
    // Text to display the victory text
    public GameObject _Line;
    public GameObject _RetryButton;
    public Vector2 _Direction;
    // Direction used to spawn the ball depending on the victory
    public GameObject _Particles;
    public AudioSource _AudioSource;

    // Use this for initialization
    void Start()
    {
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the ball enters the collider : Updates score and destroys the ball
        if (other.tag == "Ball") {
            _Score++;
            UpdateScore();

            _AudioSource.Play();
            Instantiate(_Particles, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);

            // Check for victory
            if (CheckVictory()) {
                _Line.SetActive(false);
                _VictoryText.gameObject.SetActive(true);
                _VictoryText.text = _Name + " Wins!";
                _RetryButton.SetActive(true);
            } else {
                StartCoroutine("RespawnBall");
            }
        }
    }

    // Used to spawn a new ball after a some time
    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1f);
        _GameManager.SpawnBall(_Direction);
    }

    void UpdateScore()
    {
        _ScoreText.text = _Score.ToString();
    }

    // Returns whether the player wins or not
    bool CheckVictory()
    {
        return _Score >= _MaxScore;
    }
}
