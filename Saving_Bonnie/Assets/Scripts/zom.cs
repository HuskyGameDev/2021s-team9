/**
* AUTHOR NAME: Joshua Robinson
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zom : MonoBehaviour
{
    // Variables for the zombie behavior and animations, including the waypoint array
    [SerializeField]
    Transform[] waypt;

    [SerializeField]
    public float speed = 2f;

    public SpriteRenderer zomWalk;

    public Sprite zomWalkDown;

    public Sprite zomWalkRight;

    public Sprite zomWalkLeft;

    public Animator anim;

    public int ptCount = 0;


    // Start condition, puts the zombie character at the start of the path
    void Start()
    {
        transform.position = waypt[ptCount].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
            ptCount = 0;
            transform.position = new Vector3(0.97f, 6f, 0f);
        }
    }
}
