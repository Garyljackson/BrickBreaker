using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public int Lives;
    public Text LivesText;
    public Text ScoreText;
    public bool IsGameOver;
    public GameObject GameOverPanel;
    public int NumberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        UpdateLivesText();
        UpdateScoreText();
        NumberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    public void UpdateLives(int changeInLives)
    {
        Lives += changeInLives;
        UpdateLivesText();

        if (Lives <= 0)
        {
            Lives = 0;
            GameOver();
            return;
        }
    }

    public void UpdateScore(int points)
    {
        Score += points;
        UpdateScoreText();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void UpdateNumberOfBricks()
    {
        NumberOfBricks--;

        if (NumberOfBricks <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesText()
    {
        LivesText.text = $"Lives: {Lives}";
    }

    private void UpdateScoreText()
    {
        ScoreText.text = $"Score: {Score}";
    }

    private void GameOver()
    {
        IsGameOver = true;
        GameOverPanel.SetActive(true);
    }
}
