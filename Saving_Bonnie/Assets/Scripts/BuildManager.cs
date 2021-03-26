using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is in charge of keeping track of which towers to build 
/// </summary>
public class BuildManager : MonoBehaviour
{
    //Creates an instance of itself to use singleton 
    public static BuildManager instance;

    //Stores all the tower prefabs
    public GameObject tower1, tower2, tower3, tower4; //not needed anymore?

    //Keeps track of  which tower will be built on the next click of the mouse
    private TowerBlueprint towerToBuild;

    //property for building
    public bool canBuild { get { return towerToBuild != null; } }

    /// <summary>
    /// Ensures that on the beginning of the game that only one instace of this BuildManager exists
    /// </summary>
    void Awake(){
        if(instance != null){
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    /// <summary>
    /// Makes is so the current tower to build is null
    /// </summary>
    void Start(){
        towerToBuild = null;
    }

    public void selectTower (TowerBlueprint tower){
	    towerToBuild = tower;
    }

    public void buildTowerOn (Node node){
        if (Dollars.money < towerToBuild.cost){
            Debug.Log("Not enough money");
            return;
        }
        Dollars.money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.transform.position, node.transform.rotation);
        node.tower = tower;
    }
}
