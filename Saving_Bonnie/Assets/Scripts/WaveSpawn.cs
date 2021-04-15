/**
* AUTHOR NAME: Joshua Robinson
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* LAST DATE MODIFIED: March 25, 2021
* FILE: WaveSpawn.cs
* DESCRIPTION: Creates a wave spawner which manages how many zombies and how many waves are created for each round of the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawn : MonoBehaviour
{
    // Variables to handle the zombie enemies and values for creating the waves
    [SerializeField]
    public Transform zombieEnemy;

    [SerializeField]
    public Transform spawn;

    private double[] zomCounts = {1f, 5f, 10f, 20f, 25f};

    private double[] waveTimes = {1f, 10f, 20f, 30f, 30f};

    public int waveCount = 0;

    private double timer = 2f;

    private double downTime = 3f; 

    // Update is called once per frame
    void Update()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");

        // Game Win Condition
        if (waveCount >= zomCounts.Length && (zombies.Length == 0)) {
            Debug.Log("You win!");
            SceneManager.LoadScene("Win_Screen");
            enabled = false;
        }

        if (timer <= 0) {
            StartCoroutine(NewWave(waveCount));
            Debug.Log("Next wave in: ");
            timer = downTime;
        }

        if (zombies.Length == 0 && timer > 0) {
            timer -= Time.deltaTime;
        }
    }

    // Handles the new wave spawns and creates enemies
    IEnumerator NewWave(int roundNum) {
        for (int i = 0; i < zomCounts[roundNum]; i++) {
            Instantiate(zombieEnemy, spawn.position, spawn.rotation);
            yield return new WaitForSeconds((float) (waveTimes[roundNum] / zomCounts[roundNum]));
        }
        // Increment wave count
        waveCount++;
        yield break;
    }

}