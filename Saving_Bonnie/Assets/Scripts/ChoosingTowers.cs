using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class just keeps track of the UI buttons where a user chooses which tower to place
/// </summary>
public class ChoosingTowers : MonoBehaviour
{

    public TowerBlueprint tower1;
    public TowerBlueprint tower2;
    public TowerBlueprint tower3;
    public TowerBlueprint tower4;

    //Creates an instance of the buildmanager to be able to change the current tower
    BuildManager buildManager;
    void Start(){
        buildManager = BuildManager.instance;
    }

    //Changes the current tower to tower1
    public void chooseTower1(){
        buildManager.selectTower(tower1);
    }
    //Changes the current tower to tower 2
    public void chooseTower2(){
        buildManager.selectTower(tower2);
    }
    //Changes the current tower to tower 3
    public void chooseTower3(){
        buildManager.selectTower(tower3);
    }
    //Changes the current tower to tower 4
    public void chooseTower4(){
        buildManager.selectTower(tower4);
    }

}
