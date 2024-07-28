using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.P;  // Tecla para pausar y reanudar el juego
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGameFunction();
            }
        }
    }

    void PauseGameFunction()
    {
        Time.timeScale = 0f;  // Pausa el juego
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;  // Reanuda el juego
        isPaused = false;
    }
}