using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;     // to allow other scripts to find it.

    public int lives = 5;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log("Lives remaining: " + lives);
    }

    public void LoseLife ()
    {
        lives --;

        Debug.Log ("Lives remaining: " + lives);

        if ( lives == 0 )
        {
            GameOver();
        }
    }

    private void GameOver ()
    {
        Debug.Log("Game Over");
    }
}
