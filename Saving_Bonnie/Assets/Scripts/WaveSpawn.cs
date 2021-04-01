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

public class WaveSpawn : MonoBehaviour
{
    // Variables to handle the zombie enemies and values for creating the waves
    [SerializeField]
    public Transform zombieEnemy;

    [SerializeField]
    public Transform spawn;

    public int zomCount = 0;

    private double waveCount = 1f;

    private double spawnCount = 1f;

    private double timer = 2f;

    private double waveTimes = 3f; 

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            StartCoroutine(NewWave());
            timer = waveTimes;
        }

        if (zomCount == 0 && timer > 0) {
            timer -= Time.deltaTime;
        }

        // Game Win Condition
        if (waveCount > 10 && zomCount == 0) {
            Debug.Log("You win!");
            enabled = false;
        }
    }

    // Handles the new wave spawns and creates enemies
    IEnumerator NewWave() {
        for (int i = 0; i < spawnCount; i++) {
            Instantiate(zombieEnemy, spawn.position, spawn.rotation);
            zomCount++;
            yield return new WaitForSeconds((float) (2f / spawnCount));
        }
        // Increment enemy and wave count
        waveCount++;
        spawnCount++;
    }
}