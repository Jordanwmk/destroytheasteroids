using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
		
	public GameObject asteroidExplosion;
	public GameObject playerExplosion;
	public int scoreWorth;
	private GameController gameController;

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

	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") {

			Instantiate (asteroidExplosion, transform.position, transform.rotation);

			if (other.tag == "Player"){
				Instantiate (playerExplosion, transform.position, transform.rotation);
				gameController.GameOver();
			}

			if (!gameController.isGameOver()){
				gameController.AddScore(scoreWorth);
				gameController.setDestroyEnemy(true);
			}

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
