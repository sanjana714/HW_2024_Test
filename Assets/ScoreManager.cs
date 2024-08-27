using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore;  // Static variable to store score across scenes
    public TMP_Text scoreText;  // TextMeshPro UI text for displaying the score

    void Start()
    {
        currentScore = 0;  // Initialize score
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        currentScore++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score: {currentScore}";
    }
}