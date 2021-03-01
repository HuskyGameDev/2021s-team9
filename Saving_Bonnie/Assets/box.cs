using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class box : MonoBehaviour
{
	
	[SerializeField] Color color; //initializes the defender
	[SerializeField] Tilemap map;
	

    // Update is called once per frame
    void Update()
    {
		OnMouseOver();
        //FollowMouse();
    }
	
	private void OnMouseOver(){
		Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Takes a screen point and turns it into a point in the game world
		Vector3 position = new Vector3(transform.position.x, transform.position.y, 0); //Creates the position of the mouse in the game from the world
		Vector3Int pos = new Vector3Int(Mathf.FloorToInt(position.x),Mathf.FloorToInt(position.y),Mathf.FloorToInt(position.z));
		map.SetTileFlags(pos, TileFlags.None);
		map.SetColor(map.WorldToCell(Input.mousePosition), color);
	}
	
	/*
	private void FollowMouse(){
		Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Takes a screen point and turns it into a point in the game world
		Vector3Int position = new Vector3(transform.position.x, transform.position.y, 0); //Creates the position of the mouse in the game from the world
		SetTileColor(Vector3Int position);
	}
	
	private void SetTileColor(Vector3Int position){
		map.SetTileFlags(position, TileFlags.None);
		map.SetColor(position, color);
	}
	*/
}
