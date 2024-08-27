using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay"); // Reload the Gameplay scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu"); // Load the Start Menu scene
    }
}