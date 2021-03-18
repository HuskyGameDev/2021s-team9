using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject tower4;

    private GameObject turretToBuild;

    void Awake(){
        if(instance != null){
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    void Start(){
        turretToBuild = null;
    }

    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret){
        turretToBuild = turret;
    }

}
