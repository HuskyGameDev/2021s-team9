using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will keep track of the grid system where towers can be built 
/// </summary>
public class Node : MonoBehaviour
{
    //Stores the color of the what we want the tiles to be when hovered over
    public Color hidden;
    public Vector3 positionOffset;

    [Header("Leave Empty in Unity")]
    //Stores the turret on top of the tile
    public GameObject tower;

    //Stores the cost of the provided tower, used when selling the tower
    public int cost;

    //used to render the color
    private Renderer rend;

    //Used to put the color back to its original color
    private Color visible;

    //used to build the tower on the node
    BuildManager buildManager;


    //Gets the starting color, as well as instaniate all other variables
    void Start(){
        rend = GetComponent<Renderer>();
        visible = rend.material.color;
        rend.material.color = hidden;
        buildManager = BuildManager.instance;
    }
    
    /// <summary>
    /// On the click of the mouse the turret will be placed if able
    /// </summary>
    void OnMouseDown(){

        if (buildManager.sell && tower == null) {
            Debug.Log("No Tower to be Sold Here");
            return;
        }

        if (buildManager.sell) {
            buildManager.sellTowerOn(this);
            buildManager.sell = false;
        }

        if (!buildManager.canBuild){
            return;
        }

        if(tower != null){ //Checks if a tower is already in that tile
            Debug.Log("Can't build there!");
            return;
        }

        if (PauseMenu.GameIsPaused){ //Checks if the game is paused
            Debug.Log("Game is Paused");
            return;
        }

	    buildManager.buildTowerOn(this); //Builds a tower
        buildManager.selectTower(null); //Resets the current tower to null
    }

    /// <summary>
    /// Makes the tile visible
    /// </summary>
    public void TowersAppear() {
        if (tower == null) { //Checks if a tower is already placed
            rend.material.color = visible;
        }
    }

    /// <summary>
    /// Hides the tile
    /// </summary>
    public void TowersDisappear() {
        rend.material.color = hidden;
    }
}
