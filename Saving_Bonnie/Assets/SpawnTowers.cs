using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowers : MonoBehaviour
{
	[SerializeField] GameObject defender;

	private void OnMouseDown(){
		SpawnTower(GetSquareClicked());
	}
	
	private Vector2 GetSquareClicked(){
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
		return worldPos;
	}

	private void SpawnTower(Vector2 worldPos){
		GameObject newDefender = Instantiate(defender, worldPos, Quaternion.identity) as GameObject;
	}
	
}
