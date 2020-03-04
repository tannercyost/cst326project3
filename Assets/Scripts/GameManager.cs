using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int playerScore;
    private int highScore;
    private int lives;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        lives = 3;
        if (GameObject.FindObjectOfType(typeof(GameManager)) != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        if (ScoreData.highScore > 0)
            highScore = ScoreData.highScore;

        UpdateScores();
    }

    public void AddScore(int value)
    {
        Debug.Log(value);
        playerScore = value + playerScore;

        if (playerScore > highScore)
        {
            highScore = playerScore;
            ScoreData.highScore = playerScore;
        }

        UpdateScores();
    }

    private void UpdateScores()
    {
        string stringScore = playerScore.ToString().PadLeft(4, "0"[0]);
        string stringHighScore = highScore.ToString().PadLeft(4, "0"[0]);

        scoreText.text = stringScore;
        highScoreText.text = stringHighScore;
    }

    public void playerLost()
    {
        Debug.Log("Player lost.");
        lives--;

    }
    public void ResetScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
