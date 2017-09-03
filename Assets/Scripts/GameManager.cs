using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages game elements
public class GameManager : MonoBehaviour
{

    public GameObject _Paddle2;
    public ControllerAI _PaddleAI;
    public GameObject _BallPrefab;

    // Use this for initialization
    void Start()
    {
        // Activates the Paddle2 or the AI whether it's 1 Player mode or 2 Player mode
        if (GameParameters._TwoPlayers) {
            _Paddle2.SetActive(true);
        } else {
            _PaddleAI.gameObject.SetActive(true);
        }

        // Spawns a new ball and randomly define it's direction (up or down)
        SpawnBall(new Vector2(0, Random.Range(0, 2) * 2 - 1));
    }
	
    // Update is called once per frame
    void Update()
    {
        // Go back to the menu if back is touched
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu");
        }
    }

    // Reloads the scene to restart the game
    public void RetryButton()
    {
        SceneManager.LoadScene("Game");
    }

    // Spawns a new ball at 0,0 with the given direction
    public void SpawnBall(Vector2 direction)
    {
        Ball ball = Instantiate(_BallPrefab).GetComponent<Ball>() as Ball;
        ball.SetVelocity(direction);
        if (!GameParameters._TwoPlayers) {
            _PaddleAI.SetBall(ball);
        }
    }
}
