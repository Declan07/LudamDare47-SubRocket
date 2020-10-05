using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    float restartDelay = 1f;
    public static bool GameIsPaused = false;

    public GameObject completeGameUI;
    public GameObject pauseMenuUI;

    public void CompleteGame()
    {
        Debug.Log("Game Manager reached");
        completeGameUI.SetActive(true);
    }

   public void EndGame()
    {
        if (!gameHasEnded)
        {
            
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            Debug.Log("Game over");
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
