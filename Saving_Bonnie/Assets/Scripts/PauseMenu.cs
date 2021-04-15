using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
    This class creates the functionality of the in-game pause menu
*/
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //true when game is paused

    public GameObject pauseMenuUI; //holds the pause menu UI elements

    //Update is called once per frame
    //checks for the pressing of the esc button to pause/unpause the game
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    //Resumes the game
    public void Resume ()
    {
        //remove pause menu UI and unfreeze time
        FindObjectOfType<AudioManager>().play("ButtonClick");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //pauses the game
    void Pause ()
    {
        //show pause menu UI and freeze time
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //returns the player to the main menu
    public void LoadMenu ()
    {
        FindObjectOfType<AudioManager>().play("ButtonClick");
        Resume();
        SceneManager.LoadScene("Main Menu");
    }

    //terminates the game
    public void QuitGame ()
    {
        FindObjectOfType<AudioManager>().play("ButtonClick");
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
