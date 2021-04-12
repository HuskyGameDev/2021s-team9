using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class keeps track of the interaction of the main menu buttons. It will either start the game or exit the application
/// </summary>
public class MainMenuButtons : MonoBehaviour
{
	

	//Controls what happens with the play button
	public void Play()
	{
		FindObjectOfType<AudioManager>().play("ButtonClick");
		Debug.Log("Loading"); //Prints to debug screen to ensure button was pressed
		SceneManager.LoadScene("Game_v1"); //Loads a level based on the scene selected in unity
	}

	//Controls what happens with the quit button
	public void Quit()
	{
		FindObjectOfType<AudioManager>().play("ButtonClick");
		Debug.Log("Exiting..."); //Prints to debug screen to ensure button was pressed
		Application.Quit(); //Quits the game but exiting the application

	}

	//takes the user to the tutorial page
	public void Tutorial()
    {
		FindObjectOfType<AudioManager>().play("ButtonClick");
		Debug.Log("Loading"); //Prints to debug screen to ensure button was pressed
		SceneManager.LoadScene("Tutorial"); //Loads the tutorial page
	}

	public void Menu()
	{
		FindObjectOfType<AudioManager>().play("ButtonClick");
		Debug.Log("Loading"); //Prints to debug screen to ensure button was pressed
		SceneManager.LoadScene("Main Menu"); //Loads a level based on the scene selected in unity
	}
}
