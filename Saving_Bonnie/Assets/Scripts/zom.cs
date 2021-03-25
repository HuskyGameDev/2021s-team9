/**
* AUTHOR NAME: Joshua Robinson
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* LAST DATE MODIFIED: March 25, 2021
* FILE: zom.cs
* DESCRIPTION: Creates a wave spawner which manages how many zombies and how many waves are created for each round of the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zom : MonoBehaviour
{
    // Variables for health system
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Variables for the zombie behavior and animations, including the waypoint array
    private Transform[] points;

    private float speed = 2f;

    public SpriteRenderer zomWalk;

    public Sprite zomWalkDown;

    public Sprite zomWalkRight;

    public Sprite zomWalkLeft;

    public Animator anim;

    private int ptCount = 0;

    // Start condition, puts the zombie character at the start of the path
    void Start()
    {
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
        // TESTING PURPOSES  takes away 20 health when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
           TakeDamage(20);
        }

        // Ties the count for the waypoints to a counter variable for the animations
        anim.SetInteger("counter", ptCount);

        // Points the zombie to walk towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, points[ptCount].transform.position, speed * Time.deltaTime);

        // Sets the zombie to point at a new waypoint when it reaches the previous one
        if (transform.position == points[ptCount].transform.position) {
            ptCount++;
        }

        // TESTING PURPOSES; resets the position of the zombie at the end so it continues to go along the path
        if (ptCount == points.Length) {
            Destroy(gameObject); 
        }
    }

    // Damage System for zombies
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }
    
}
