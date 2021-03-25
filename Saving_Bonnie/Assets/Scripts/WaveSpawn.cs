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

    private double waveCount = 1f;

    private double enemyCount = 1f;

    private double timer = 2f;

    private double waveTimes = 3f; 

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            StartCoroutine(NewWave());
            timer = waveTimes;
        }

        timer -= Time.deltaTime;

        if (waveCount > 10) {
            Debug.Log("END!");
            enabled = false;
        }
    }

    IEnumerator NewWave() {
        Debug.Log("WAVE!");
        for (int i = 0; i < enemyCount; i++) {
            Instantiate(zombieEnemy, spawn.position, spawn.rotation);
            yield return new WaitForSeconds((float) (2f / enemyCount));
        }
        waveCount++;
        enemyCount++;
    }
}
