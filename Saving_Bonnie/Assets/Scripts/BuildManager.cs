using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is in charge of keeping track of which towers to build 
/// </summary>
public class BuildManager : MonoBehaviour {
    //Creates an instance of itself to use singleton 
    public static BuildManager instance;

    //Stores all the tower prefabs
    public GameObject tower1, tower2, tower3, tower4; //not needed anymore?

    //Keeps track of  which tower will be built on the next click of the mouse
    private TowerBlueprint towerToBuild;

    //Tells us if the next tower is being built or sold
    public bool sell;

    //property for building
    public bool canBuild { get { return towerToBuild != null; } }

    //Stores all the nodes in the game that don't have towers
    private GameObject[] nodes;

    /// <summary>
    /// Ensures that on the beginning of the game that only one instace of this BuildManager exists
    /// </summary>
    void Awake() {

        if (instance != null) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;

    }

    /// <summary>
    /// Makes is so the current tower to build is null
    /// </summary>
    void Start() {
        towerToBuild = null;
        nodes = GameObject.FindGameObjectsWithTag("nodes");
        sell = false;
    }

    /// <summary>
    /// Changes the tower that will be built to the one clicked on in the UI
    /// </summary>
    /// <param name="tower"></param>
    public void selectTower(TowerBlueprint tower) {
        towerToBuild = tower;
    }

    /// <summary>
    /// Builds the tower on the desired node
    /// </summary>
    /// <param name="node"></param> The node the user clicked on
    public void buildTowerOn(Node node) {
        if (Dollars.money < towerToBuild.cost) {
            Debug.Log("Not enough money");
            return;
        }

        Dollars.money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.transform.position, Quaternion.Euler(0, 0, 270));
        node.tower = tower;
        node.cost = towerToBuild.cost;
        if (tower.name.Contains("Tower_4_Prefab"))
        {
            FindObjectOfType<AudioManager>().play("TowerPlace");
            FindObjectOfType<AudioManager>().play("ChaChing");
        }
        else
        {
            FindObjectOfType<AudioManager>().play("TowerPlace");
        }
        
        hideTiles();

    }

    /// <summary>
    /// This will sell the tower on the selected tile
    /// </summary>
    /// <param name="node"></param> The node the user clicked on
    public void sellTowerOn(Node node) {

        if (PauseMenu.GameIsPaused) {
            Debug.Log("Game is Paused");
            return;
        }

        if (node.tower.name.Contains("Tower_1_Prefab")) {
            //TODO make it so towers have buff removed upon selling CS tower
        }

        Dollars.money += node.cost / 2;
        Destroy(node.tower);
        node.tower = null;
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
