using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    private int playerScore;
    private int highScore;
    private int lives;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private GameObject player;
    public UnityEvent events;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");

        lives = 3;
        if (GameObject.FindObjectOfType(typeof(GameManager)) != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        if (ScoreData.highScore > 0)
            highScore = ScoreData.highScore;
        if (player != null) 
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
        Debug.Log("Player lost. Lives left: " + lives);
        
        if (lives > 0)
        {
            player.transform.position = new Vector3(0, -4.5f, 0);
        }
        else
        {
            player.transform.position = new Vector3(100, -14.5f, 0);
            Debug.Log("You ran out of lives.");
            SceneManager.LoadScene("Lost");
        }
        lives--;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Log(string msg)
    {
        Debug.Log(gameObject.name + ": " + msg);
    }
}
