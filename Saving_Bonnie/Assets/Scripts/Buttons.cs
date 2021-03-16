using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string levelToLoad = "Game";

	//Controls what happens with the play button
	public void Play()
	{
		Debug.Log("Loading"); //Prints to debug screen to ensure button was pressed
		SceneManager.LoadScene(levelToLoad); //Loads a level based on the scene selected in unity
	}

	//Controls what happens with the quit button
	public void Quit()
	{
		Debug.Log("Exiting..."); //Prints to debug screen to ensure button was pressed
		Application.Quit(); //Quits the game but exiting the application

	}
}
