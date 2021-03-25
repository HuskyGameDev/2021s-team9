using UnityEngine;

public class shop : MonoBehaviour
{

	public TowerBlueprint tower1, tower2, tower3, tower4;

	BuildManager buildManager;
	
	void Start() {
		buildManager = BuildManager.instance;
	}

	public void PurchaseTower1(){
		buildManager.selectTower(tower1);
		Debug.Log("Tower 1 Selected");
	}

	public void PurchaseTower2(){
		buildManager.selectTower(tower2);
		Debug.Log("Tower 2 Selected");
	}

	public void PurchaseTower3(){
		buildManager.selectTower(tower3);
		Debug.Log("Tower 3 Selected");
	}

	public void PurchaseTower4(){
		buildManager.selectTower(tower4);
		Debug.Log("Tower 4 Selected");
	}
}
