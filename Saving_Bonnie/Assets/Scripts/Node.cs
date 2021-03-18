﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will keep track of the grid system where towers can be built 
/// </summary>
public class Node : MonoBehaviour
{
    //Stores the color of the what we want the tiles to be when hovered over
    public Color hoverColor;
    //Stores the turret on top of the tile
    private GameObject turret;
    //used to render the color
    private Renderer rend;
    //Used to put the color back to its original color
    private Color startColor;
    //used to build the tower on the node
    BuildManager buildManager;
    //Gets the starting color, as well as instaniate all other variables
    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        rend.material.color = hoverColor;
        buildManager = BuildManager.instance;
    }
    
    /// <summary>
    /// On the click of the mouse the turret will be placed if able
    /// </summary>
    void OnMouseDown(){
        if(turret != null){ //Checks if a tower is already in that tile
            Debug.Log("Can't build there!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTowerToBuild();
        if(turretToBuild == null){ //Checks if a tower has been choosen yet
                    Debug.Log("Choose a tower first");
                    return;
                }
        if (PauseMenu.GameIsPaused){ //Checks if the game is paused
            Debug.Log("Game is Paused");
            return;
        }
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation); //Builds a tower on the tile
        buildManager.setTowerToBuild(null); //Resets the current tower to null
    }

    /// <summary>
    /// Used to change the color of the tile when the mouse is over it
    /// </summary>
    void OnMouseEnter(){
        rend.material.color = startColor;
    }

    /// <summary>
    /// Used to reset the color of the tile when the mouse moves off it
    /// </summary>
    void OnMouseExit(){
        rend.material.color = hoverColor;
    }
}