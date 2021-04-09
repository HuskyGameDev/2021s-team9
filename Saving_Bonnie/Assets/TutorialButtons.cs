using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class keeps track of the interaction of the tutorial buttons
/// </summary>
public class TutorialButtons : MonoBehaviour
{

	//takes the user to the menu page
	public void Menu()
	{
		FindObjectOfType<AudioManager>().play("ButtonClick");
		Debug.Log("Loading"); //Prints to debug screen to ensure button was pressed
		SceneManager.LoadScene("Main Menu"); //Loads the menu page
	}
}
