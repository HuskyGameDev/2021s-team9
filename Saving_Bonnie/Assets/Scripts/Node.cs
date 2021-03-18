using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        rend.material.color = hoverColor;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown(){
        if(turret != null){
            Debug.Log("Can't build there!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        if(turretToBuild == null){
                    Debug.Log("Choose a tower first");
                    return;
                }
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        buildManager.setTurretToBuild(null);
    }

    void OnMouseEnter(){
        rend.material.color = startColor;
    }

    void OnMouseExit(){
        rend.material.color = hoverColor;
    }
}
