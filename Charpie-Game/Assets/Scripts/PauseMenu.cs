using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        // Toggle between pasued and resumed when the escape key is pressed
        {
            if (GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Resume the game when resume is pressed
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Pause the game when pause is pressed
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartGame()
    {
        // Reload the scene if the restart button is pressed
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        // Go to the main menu if main menu is pressed
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Quit the game if Quit is pressed 
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}