using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;
    public float range = 5;
    public float cooldown = 3f;
    public float firerate = 1f;
    private float fireCountdown = 0f;

    public zom zomClass;

    private string enemyTag = "zombie";

    //Causes updateTarget to be called once every .5 seconds
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    void Update() {

        if (target == null)
            return;

        if(fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / firerate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void UpdateTarget(){
        GameObject[] zombies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestZombie = null;
        foreach(GameObject zombie in zombies) {
            float distanceToZombies = Vector2.Distance(transform.position, zombie.transform.position);
            if(distanceToZombies < shortestDistance) {
                shortestDistance = distanceToZombies;
                nearestZombie = zombie;
            }
        }

        if(nearestZombie != null && shortestDistance <= range) {
            target = nearestZombie.transform;
        } else {
            target = null;
        }
    }

    void Shoot() {
        Debug.Log("Shoot");
    }
    
}
