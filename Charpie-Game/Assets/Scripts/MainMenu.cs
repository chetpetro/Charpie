// Script Written By: Jordan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public void PlayGame()
    {
        // Move to the next scene when the play button is pressed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Quit the game when quit is pressed
        Application.Quit();
    }

    public void Home()
    {
        //Home
        SceneManager.LoadScene(0);
    }

}
