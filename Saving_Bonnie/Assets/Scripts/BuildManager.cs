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

    private GameObject[] nodes;

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
        nodes = GameObject.FindGameObjectsWithTag("nodes");
    }

    //Changes the current tower selection to the new one
    public void selectTower (TowerBlueprint tower){
	    towerToBuild = tower;
    }

    /// <summary>
    /// Builds the tower on the desired node
    /// </summary>
    /// <param name="node"></param>
    public void buildTowerOn (Node node){
        if (Dollars.money < towerToBuild.cost){
            Debug.Log("Not enough money");
            return;
        }
        Dollars.money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.transform.position, node.transform.rotation);
        node.tower = tower;
        FindObjectOfType<AudioManager>().play("TowerPlace");        
        hideTiles(); 
    }

    /// <summary>
    /// Makes all the tiles vanish
    /// </summary>
    private void hideTiles() {
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i].GetComponent<Node>().TowersDisappear();
        }
    }
}
