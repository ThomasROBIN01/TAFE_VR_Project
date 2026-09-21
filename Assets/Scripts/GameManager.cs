using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;     // to allow other scripts to find it.

    public TMP_Text scoreText;
    public TMP_Text livesText;

    public int score;

    public int lives = 5;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log("Lives remaining: " + lives);
        scoreText.text = "Score: 0";
        livesText.text = "Lives: " + lives;
    }

    public void LoseLife ()
    {
        lives --;

        Debug.Log ("Lives remaining: " + lives);
        livesText.text = "Lives: " + lives;

        if ( lives == 0 )
        {
            GameOver();
        }
    }

    private void GameOver ()
    {
        Debug.Log("Game Over");
    }

    public void UpdateScore (int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = "Score: " + score;
    }
}
