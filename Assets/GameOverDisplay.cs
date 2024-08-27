using UnityEngine;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public TMP_Text finalScoreText;  // TextMeshPro UI text for displaying the final score

    void Start()
    {
        // Display the score in the Game Over screen
        finalScoreText.text = $"Final Score: {ScoreManager.currentScore}";
    }
}