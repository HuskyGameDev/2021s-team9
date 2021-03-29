using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Leave Empty in Unity")]
    public Transform target;

    public float range = 5;
    public float cooldown = 3f;
    public float firerate = 1f;
    private float fireCountdown = 0f;

    private string enemyTag = "zombie";

    //Causes updateTarget to be called once every .5 seconds
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f); //Makes UpdateTarget run every 1/2 second
    }

    /// <summary>
    /// Calls the shoot funciton when the countdown is zero
    /// </summary>
    void Update() {

        if (target == null) //Does nothing if no target
            return;

        if(fireCountdown <= 0f) {
            Shoot(); //Shoots
            fireCountdown = 1f / firerate; //Causes the tower to have to wait to shoot
        }

        fireCountdown -= Time.deltaTime; //Ticks the cooldown down with each second

    }

    /// <summary>
    /// Updates the current target to a new one when a zombie gets in range or when one is closer than its current target
    /// </summary>
    void UpdateTarget(){
        GameObject[] zombies = GameObject.FindGameObjectsWithTag(enemyTag); //Finds every zombie in the game
        float shortestDistance = Mathf.Infinity; //Sets the shortest distance to infinity so every value is smaller than it
        GameObject nearestZombie = null;
        foreach(GameObject zombie in zombies) { //Checks every zombie in the game
            float distanceToZombies = Vector2.Distance(transform.position, zombie.transform.position); //Gets the distance to said zombie
            if(distanceToZombies < shortestDistance) { //Checks if the zombie is closer than its previous target
                shortestDistance = distanceToZombies;
                nearestZombie = zombie;
            }
        }
        //Changes target once the target is dead, or goes to null if none in range
        if(nearestZombie != null && shortestDistance <= range) {
            target = nearestZombie.transform;
        } else {
            target = null;
        }
    }

    /// <summary>
    /// Causes the tower to damage the zombie
    /// </summary>
    void Shoot() {
        target.GetComponent<zom>().TakeDamage(20);
    }
    
}
