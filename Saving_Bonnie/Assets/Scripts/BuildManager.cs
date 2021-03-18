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
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject tower4;

    //Keeps track of  which tower will be built on the next click of the mouse
    private GameObject towerToBuild;

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

    /// <summary>
    /// Returns what tower is to be built or null if none are selected
    /// </summary>
    /// <returns></returns>
    public GameObject GetTowerToBuild(){
        return towerToBuild;
    }

    /// <summary>
    /// Sets the current tower variable to the tower the user clicked on in the UI
    /// </summary>
    /// <param name="tower"> The tower they wish to build next </param>
    public void setTowerToBuild(GameObject tower){
        towerToBuild = tower;
    }

}
