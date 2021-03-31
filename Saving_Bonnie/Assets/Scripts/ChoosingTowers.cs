using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class just keeps track of the UI buttons where a user chooses which tower to place
/// </summary>
public class ChoosingTowers : MonoBehaviour
{
    //Stores each prefab of the towers
    public TowerBlueprint tower1;
    public TowerBlueprint tower2;
    public TowerBlueprint tower3;
    public TowerBlueprint tower4;
   
    //Stores every node in the game
    private GameObject[] nodes;

    //Creates an instance of the buildmanager to be able to change the current tower
    BuildManager buildManager;
    
    
    void Start(){
        buildManager = BuildManager.instance;
        nodes = GameObject.FindGameObjectsWithTag("nodes");
    }

    //Changes the current tower to tower1
    public void chooseTower1(){
        buildManager.selectTower(tower1);
        buildManager.sell = false;
        seeTiles();
    }
    //Changes the current tower to tower 2
    public void chooseTower2(){
        buildManager.selectTower(tower2);
        buildManager.sell = false;
        seeTiles();
    }
    //Changes the current tower to tower 3
    public void chooseTower3(){
        buildManager.selectTower(tower3);
        buildManager.sell = false;
        seeTiles();
    }
    //Changes the current tower to tower 4
    public void chooseTower4(){
        buildManager.selectTower(tower4);
        buildManager.sell = false;
        seeTiles();
    }

   /// <summary>
   /// Selects the tower to be null and then sells the tower
   /// </summary>
    public void sellTower() {
        buildManager.selectTower(null); //Sets the tower to be built to null in case previous tower is chosen
        buildManager.sell = true; //Tells the buildmanager the tower will be sold
        seeTiles();
    }

    /// <summary>
    /// Turns every tile visible that can be built on
    /// </summary>
    private void seeTiles() {
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i].GetComponent<Node>().TowersAppear();
        }
    }

}
