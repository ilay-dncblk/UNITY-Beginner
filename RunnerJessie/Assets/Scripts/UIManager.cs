using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject gameScreen;

    public GameObject pauseScreen;

    public void Start()
    {
        startScreen.SetActive(true);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void GameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        RestartLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        RestartLevel();
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
