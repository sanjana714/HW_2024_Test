using System.Collections;
using UnityEngine;
using TMPro;

public class Pulpit : MonoBehaviour
{
    private float destroyTime;
    private float timeRemaining;
    public TextMeshPro timerText; // Reference to the TextMeshPro component on the pulpit

    public void Initialize(float destroyTime)
    {
        this.destroyTime = destroyTime;
        this.timeRemaining = destroyTime;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText(); // Update the timer display
            yield return null;
        }

        Destroy(gameObject);
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = timeRemaining.ToString("F1"); // Display timer with one decimal place
        }
    }
}