using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string levelToLoad = "Game";

	public void Play()
	{
		Debug.Log("Play");
		SceneManager.LoadScene(levelToLoad);
	}

	public void Quit()
	{
		Debug.Log("Exiting...");
		Application.Quit();
	}
}
