using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject doofus;

    void Update()
    {
        if (doofus.transform.position.y < -5f) // Adjust the y value as necessary
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}