using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private GameObject target;
    public float range = 15f;
    public float cooldown = 2f;
    public float firerate = 1f;

    public string enemyTag = "zombie";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        GameObject[] zombies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestZombie = null;
        foreach(GameObject zombie in zombies) {

        }
    }
}
