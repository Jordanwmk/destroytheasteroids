using UnityEngine;
using System.Collections;

public class DestroyByBorder : MonoBehaviour {

	private GameController gameController;
	private int scorePenalty = -5;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null){ 
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script. Error from Collision.cs");
		}
	}

	void OnTriggerExit(Collider other){

		if (other.tag == "Boundary") {
			if (!gameController.isGameOver()){
				gameController.AddScore(-5);
			}
		}
		Destroy(other.gameObject);
	}
}
