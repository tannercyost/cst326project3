using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int playerScore;
    private int highScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        highScore = 0;
    }

    public void AddScore(int value)
    {
        Debug.Log(value);
        playerScore = value + playerScore;

        if (playerScore > highScore)
        {
            highScore = playerScore;
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

    public void ResetScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
