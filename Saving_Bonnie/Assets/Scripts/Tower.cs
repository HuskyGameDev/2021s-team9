using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class holds variables unique to each tower and allows the towers to shoot or use passive abilities
/// Author - Tyler Becker
/// </summary>
public class Tower : MonoBehaviour
{
    [Header("Leave Empty in Unity")]
    public Transform target; //Target mob that will be shot

    public float range = 5; //Range of towers
    public float cooldown = 3f; //Unknown if used
    public float firerate = 1f; //Used to calculte cooldown between shots
    public float passiveTimer = 5f; //How often the passive abilities can happen
    private float fireCountdown = 0f; //Counts down how long until the next time the tower can shoot
    public int damage; //Amount of damage tower does

    private string enemyTag = "zombie"; //Used to find the mobs with the correct tags

    /// <summary>
    /// Causes the damage to be set for the towers, and also causes methods to repeat at desired intervals
    /// </summary>
    void Start()
    {

        if (this.name.Contains("Tower_1_Prefab")) {
            damage = 0;
            buffTowers();
        } else if (this.name.Contains("Tower_2_Prefab")) {
            damage = 10;
        } else if (this.name.Contains("Tower_3_Prefab")) {
            damage = 20;
        } else if (this.name.Contains("Tower_4_Prefab")) {
            damage = 0;
        } else {
            Debug.Log("Unknown Tower");
        }

        InvokeRepeating("UpdateTarget", 0f, .5f); //Makes UpdateTarget run every 1/2 second
        InvokeRepeating("passiveAbilities", 0f, passiveTimer); //Makes passiveAbilities run according to the timer variable

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
    /// Method causes passive abilities to occur 
    /// </summary>
    void passiveAbilities() {
        if (this.name.Contains("Tower_4_Prefab")) {
            Debug.Log("Placeholder for Generating Money");
        }
    }

    /// <summary>
    /// Buffs tower upon the creation of CS towers
    /// </summary>
    void buffTowers() {
        GameObject[] nearbyTowers = GameObject.FindGameObjectsWithTag("Buffable_Towers");
        foreach(GameObject tower in nearbyTowers) {
            float distanceToTowers = Vector2.Distance(transform.position, tower.transform.position); //Gets the distance to each tower
            if (distanceToTowers < range) { //Check if the tower is in range
                tower.GetComponent<Tower>().damage = (int)(tower.GetComponent<Tower>().damage * 1.2); //Increases damage by 20%
            }
        }
    }

    /// <summary>
    /// Causes the tower to damage the zombie
    /// </summary>
    void Shoot() {
        target.GetComponent<zom>().TakeDamage(damage);
        if (name.Contains("Tower_2_Prefab") && target.GetComponent<zom>().speed == 1) { //Checks if the tower is the EE tower and if the zombie hasn't been slowed down yet
            float oldSpeed = target.GetComponent<zom>().speed; //Gets the zombies original speed
            StartCoroutine(Slowdown(oldSpeed)); //Calls the slowdown method which will wait 2 seconds before putting the zombie back to its default speed
        }
    }

    /// <summary>
    /// Has the system slow the zombie down for 2 seconds
    /// </summary>
    /// <param name="oldSpeed"></param> The default speed of the zombie
    /// <returns></returns>
    IEnumerator Slowdown(float oldSpeed) {
        target.GetComponent<zom>().speed = (float)(oldSpeed * .7); //Reduces the zombies speed
        yield return new WaitForSecondsRealtime(2); //Causes the system to wait 2 seconds before going to the next line
        if (target != null) { //Checks if the target died during the wait
            target.GetComponent<zom>().speed = oldSpeed; //Resets the zombies speed
        }
    }
    
}
