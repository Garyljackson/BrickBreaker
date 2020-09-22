using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;
    public int Lives;
    public Text LivesText;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesText();
        UpdateScoreText();
    }

    public void UpdateLives(int changeInLives)
    {
        Lives += changeInLives;
        UpdateLivesText();
    }

    public void UpdateScore(int points)
    {
        Score += points;
        UpdateScoreText();
    }

    private void UpdateLivesText()
    {
        LivesText.text = $"Lives: {Lives}";
    }

    private void UpdateScoreText()
    {
        ScoreText.text = $"Score: {Score}";
    }
}
