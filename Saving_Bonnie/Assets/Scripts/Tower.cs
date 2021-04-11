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

    [Header("For CS, EE, and ME Towers")]
    public float range; //Range of towers

    [Header("For EE and ME Towers")]
    public float cooldown; //Unknown if used
    public float firerate; //Used to calculte cooldown between shots
    public int damage; //Amount of damage tower does
    private float fireCountdown; //Counts down how long until the next time the tower can shoot
    private int baseDamage; //Used to know if the tower has been buffed

    [Header("For EE Towers")]
    public int slowdownTime;
    public float slowdownAmount;

    [Header("For Business Towers")]
    public float passiveTimer; //How often the passive abilities can happen
    public int income;
    private int baseIncome;

    private string enemyTag = "zombie"; //Used to find the mobs with the correct tags

    public Animator anim; 

    /// <summary>
    /// Causes the damage to be set for the towers, and also causes methods to repeat at desired intervals
    /// </summary>
    void Start() {
        if (name.Contains("Tower_1_Prefab")) { //Checks if it is the CS tower 
            buffTowers();
        } else if (name.Contains("Tower_2_Prefab") || name.Contains("Tower_3_Prefab")) { //Checks if the towers are EE or ME
            baseDamage = damage;
            InvokeRepeating("UpdateTarget", 0f, .5f); //Makes UpdateTarget run every 1/2 second
        } else if (name.Contains("Tower_4_Prefab")) { //Checks if it is the Business Tower
            baseIncome = income;
            InvokeRepeating("passiveAbilities", 0f, passiveTimer); //Makes passiveAbilities run according to the timer variable
        } else { //Prints if no known tower was found
            Debug.Log("Unknown Tower");
        }

        anim = gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// Calls the shoot funciton when the countdown is zero
    /// </summary>
    void Update() {
        if (name.Contains("Tower_1_Prefab")) {
            buffTowers();
        }

        if (target == null) //Does nothing if no target
            return;

        if(fireCountdown <= 0f) {
            Shoot(); //Shoots
            fireCountdown = 1f / firerate; //Causes the tower to have to wait to shoot
        }

        fireCountdown -= Time.deltaTime; //Ticks the cooldown down with each second

    }

    /// <summary>
    /// Called when the tower is sold/destroyed 
    /// </summary>
    void OnDestroy() {
        if (name.Contains("Tower_1_Prefab")) { //Checks if it was the CS tower destroyed
            debuffTower(); //Debuffs the towers that it previously buffed 
        }
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
            anim.SetBool("money", true);
            Dollars.money += income; //Increases money by income 
            anim.SetBool("money", false);
        }
    }

    /// <summary>
    /// Buffs tower upon the creation of CS towers
    /// </summary>
    void buffTowers() {

        GameObject[] nearbyTowers = GameObject.FindGameObjectsWithTag("Buffable_Towers");
        foreach(GameObject tower in nearbyTowers) {

            float distanceToTowers = Vector2.Distance(transform.position, tower.transform.position); //Gets the distance to each tower
            int damage = tower.GetComponent<Tower>().damage; //Gets current damage of tower
            int baseDamage = tower.GetComponent<Tower>().baseDamage; //Gets base damage of tower
            int income = tower.GetComponent<Tower>().income; //Gets current income of tower
            int baseIncome = tower.GetComponent<Tower>().baseIncome; //Gets base income of tower

            if (distanceToTowers < range) { //Check if the tower is in range and hasn't been buffed yet

                if (tower.name.Contains("Tower_4_Prefab") && income == baseIncome) { //Checks if it is a business tower and if income has been buffed yet
                    tower.GetComponent<Tower>().income += 5; //buffs income
                    FindObjectOfType<AudioManager>().play("BeepBoop"); //plays buffing sound
                } else if ((tower.name.Contains("Tower_2_Prefab") || tower.name.Contains("Tower_3_Prefab")) && damage == baseDamage) { //checks if EE or ME tower and if it has been buffed yet
                    tower.GetComponent<Tower>().damage = (int)(damage * 1.2); //Increases damage by 20%
                    FindObjectOfType<AudioManager>().play("BeepBoop"); //plays buffing sound
                }

            }
        }
    }

    /// <summary>
    /// Does the reverse of the BuffTowers() method
    /// </summary>
    public void debuffTower() {
        GameObject[] nearbyTowers = GameObject.FindGameObjectsWithTag("Buffable_Towers");
        foreach (GameObject tower in nearbyTowers) {

            float distanceToTowers = Vector2.Distance(transform.position, tower.transform.position); //Gets the distance to each tower
            
            //Gets current and base values of damage and income
            int damage = tower.GetComponent<Tower>().damage;
            int baseDamage = tower.GetComponent<Tower>().baseDamage;
            int income = tower.GetComponent<Tower>().income;
            int baseIncome = tower.GetComponent<Tower>().baseIncome;

            if (distanceToTowers < range) { //Check if the tower is in range

                if (tower.name.Contains("Tower_4_Prefab") && income > baseIncome) {
                    tower.GetComponent<Tower>().income -= 5; //Decreses income by 5
                } else if ((tower.name.Contains("Tower_2_Prefab") || tower.name.Contains("Tower_3_Prefab")) && damage > baseDamage) {
                    tower.GetComponent<Tower>().damage = (int)(damage / 1.2); //Decreases damage by 20%
                }

            }
        }
    }

    /// <summary>
    /// Causes the tower to damage the zombie
    /// </summary>
    void Shoot() {
        

        float currentSpeed = target.GetComponent<zom>().currentSpeed; //Gets the current speed of the zombie
        float baseSpeed = target.GetComponent<zom>().baseSpeed; //Gets the base speed of the zombie

        if (name.Contains("Tower_2_Prefab") && baseSpeed == currentSpeed) //Checks if the tower is the EE tower and if the zombie hasn't been slowed down yet
        {
            FindObjectOfType<AudioManager>().play("ElectricShock"); //Plays sound linked to tower
            target.GetComponent<zom>().TakeDamage(damage); //Damages zombie
            StartCoroutine(Slowdown(baseSpeed)); //Calls the slowdown method which will wait 2 seconds before putting the zombie back to its default speed
        } 
        else if (name.Contains("Tower_3_Prefab")) //ME tower
        {
            anim.SetBool("shoot", true);
            target.GetComponent<zom>().TakeDamage(damage); //damages zombie
            FindObjectOfType<AudioManager>().play("Crossbow"); //plays sound linked to the tower
            anim.SetBool("shoot", false);
        }
    }

    /// <summary>
    /// Has the system slow the zombie down for 2 seconds
    /// </summary>
    /// <param name="oldSpeed"></param> The default speed of the zombie
    /// <returns></returns>
    IEnumerator Slowdown(float oldSpeed) {
        anim.SetBool("shock", true);
        target.GetComponent<zom>().currentSpeed = oldSpeed * slowdownAmount; //Reduces the zombies speed
        target.GetComponent<zom>().anim.speed *= slowdownAmount;
        yield return new WaitForSecondsRealtime(slowdownTime); //Causes the system to wait 2 seconds before going to the next line
        if (target != null) { //Checks if the target died during the wait
            target.GetComponent<zom>().currentSpeed = oldSpeed; //Resets the zombies speed
            target.GetComponent<zom>().anim.speed /= slowdownAmount;
        }
        anim.SetBool("shock", false);
    }
    
}
