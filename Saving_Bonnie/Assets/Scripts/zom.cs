/**
* AUTHOR NAMES: Joshua Robinson and Eric Goulet
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zom : MonoBehaviour
{
    //variables for health system
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Variables for the zombie behavior and animations, including the waypoint array
    [SerializeField]
    Transform[] waypt = {Waypoint_1, Waypoint_2, Waypoint_3, Waypoint_4, Waypoint_5, Waypoint_6};

    [SerializeField]
    public float speed = 2f;

    public SpriteRenderer zomWalk;

    public Sprite zomWalkDown;

    public Sprite zomWalkRight;

    public Sprite zomWalkLeft;

    public Animator anim;

    public int ptCount = 0;


    // Start condition, puts the zombie character at the start of the path and sets health
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        transform.position = waypt[ptCount].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TESTING PURPOSES  takes away 20 health when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        // Ties the count for the waypoints to a counter variable for the animations
        anim.SetInteger("counter", ptCount);

        // Points the zombie to walk towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypt[ptCount].transform.position, speed * Time.deltaTime);

        // Sets the zombie to point at a new waypoint when it reaches the previous one
        if (transform.position == waypt[ptCount].transform.position) {
            ptCount++;
        }

        // TESTING PURPOSES; resets the position of the zombie at the end so it continues to go along the path
        if (ptCount == waypt.Length) {
            enabled = false;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }
}
