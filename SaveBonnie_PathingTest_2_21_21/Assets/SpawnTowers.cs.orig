using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnTowers : MonoBehaviour
{
	[SerializeField] GameObject defender; //initializes the defender
	[SerializeField] Tilemap map;


	//occurs when mouse is clicked in game
	private void OnMouseDown(){
		SpawnTower(GetSquareClicked()); //Calls the spawn tower method with the return value from GetSquareClicked method
	}
	
	//finds the world position from the screen
	private Vector3 GetSquareClicked(){
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //Creates a vector based on x and y values
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); //Takes the previous value and finds a world point based on them
		
		//GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
		Vector3Int cellPosition = map.WorldToCell(worldPos);
		transform.position = map.GetCellCenterWorld(cellPosition);
		//Vector3 worldPos2 = gridLayout.CellToWorld(cellPosition);
		
		Debug.Log("World Position: " + worldPos + " Cell Position " + cellPosition);
		return cellPosition; //returns said point
		
		
	}
	
	private Vector2 SnapToGrid(Vector3 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX,newY);
	}

	//Creates a tower
	private void SpawnTower(Vector3 worldPos){
		GameObject newDefender = Instantiate(defender, worldPos, Quaternion.identity) as GameObject; //places a tower at the world point with the selected prefab in Unity
	}
	
}
