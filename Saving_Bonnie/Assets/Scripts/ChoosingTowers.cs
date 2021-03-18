using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingTowers : MonoBehaviour
{

    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void chooseTower1(){
        buildManager.setTurretToBuild(buildManager.tower1);
    }

    public void chooseTower2(){
        buildManager.setTurretToBuild(buildManager.tower2);
    }

    public void chooseTower3(){
        buildManager.setTurretToBuild(buildManager.tower3);
    }

    public void chooseTower4(){
            buildManager.setTurretToBuild(buildManager.tower4);
        }

}
