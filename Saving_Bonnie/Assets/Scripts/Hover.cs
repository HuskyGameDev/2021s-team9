using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class just follows the mouse by putting a sprite on the screen and going where the mouse points
/// </summary>
public class Hover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     	FollowMouse();	//Calls FollowMouse method
    }

	//Makes the game follow the mouse on the screen
	private void FollowMouse(){
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Takes a screen point and turns it into a point in the game world
		transform.position = new Vector3(transform.position.x, transform.position.y, 0); //Creates the position of the mouse in the game from the world
	}

}