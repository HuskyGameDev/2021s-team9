﻿/**
* AUTHOR NAME: Joshua Robinson
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* LAST DATE MODIFIED: March 25, 2021
* FILE: zom.cs
* DESCRIPTION: Creates a wave spawner which manages how many zombies and how many waves are created for each round of the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zom : MonoBehaviour
{
    // Variables for health system
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Variables for the zombie behavior and animations, including the waypoint array
    public GameObject spawner;

    private Transform[] points;

    public Animator anim;

    public float baseSpeed; //Holds the base speed of the zombie
    [Header("Leave Empty in Unity")]
    public float currentSpeed; //Stores the current speed of the zombie

    private int ptCount = 0;

    // Start condition, puts the zombie character at the start of the path
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        anim.speed = 0.6f;

        currentSpeed = baseSpeed;

        points = new Transform[waypt.pts.Length];
        for (int i = 0; i < waypt.pts.Length; i++) {
            points[i] = waypt.pts[i];
        }

        gameObject.layer = 1;

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        transform.position = points[ptCount].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Points the zombie to walk towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, points[ptCount].transform.position, currentSpeed * Time.deltaTime);

        if (transform.position == points[1].transform.position) {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        } else if (transform.position == points[2].transform.position || transform.position == points[4].transform.position) {
            transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        } else if (transform.position == points[3].transform.position) {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }

        // Sets the zombie to point at a new waypoint when it reaches the previous one
        if (transform.position == points[ptCount].transform.position) {
            ptCount++;
        }

        // Kills the zombie at the end, and takes away lives
        if (ptCount == points.Length) {
            Destroy(gameObject);
	        Dollars.lives--;
            if(Dollars.lives <= 0) {
                SceneManager.LoadScene("GameOver_Screen");
            }
            enabled = false;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Dollars.money += 50;
            enabled = false;
        }
    }

    // Damage System for zombies
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public IEnumerator Slowdown(float slowdownAmount, int slowdownTime) {
        currentSpeed = baseSpeed * slowdownAmount; //Reduces the zombies speed
        anim.speed *= slowdownAmount;
        yield return new WaitForSecondsRealtime(slowdownTime); //Causes the system to wait 2 seconds before going to the next line
        if (this != null) {
            currentSpeed = baseSpeed; //Resets the zombies speed
            anim.speed /= slowdownAmount;
        }
    }
    
}
