﻿/**
* AUTHOR NAME: Joshua Robinson
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* LAST DATE MODIFIED: March 18, 2021
* FILE: WaveSpawn.cs
* DESCRIPTION: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    public Transform zombieEnemy;

    [SerializeField]
    public Transform spawn;

    private int waveCount = 1;

    private int enemyCount = 1;

    private int countdown = 2;

    private int waveTimes = 5; 

    // Start is called before the first frame update
    void Start() 
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0) {
            for (int i = 0; i < enemyCount; i++) {
                Instantiate(zombieEnemy, spawn.position, spawn.rotation);
                new WaitForSeconds(1f);
            }
            countdown = waveTimes;
        }

        countdown -= (int) Time.deltaTime;
        waveCount++;
        enemyCount++;

        if (waveCount > 15) {
            return;
        }
    }
}
