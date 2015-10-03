using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] asteroids;
	public Vector3 asteroidTransform;
	public int numberOfAsteroids;
	public float spawnGap;
	public float startGap;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool restart;
	private bool gameOver;

	private bool destroyedEnemy = false;

	void Start(){
		score = 0;
		restart = false;
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startGap);

		while (true) {
			int hazardNumber;

			hazardNumber =  Random.Range(0,asteroids.Length);
			Vector3 spawnPosition = new Vector3 (Random.Range (-asteroidTransform.x, asteroidTransform.x), asteroidTransform.y, asteroidTransform.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (asteroids[hazardNumber], spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnGap);

			if (gameOver){
				restartText.text = "Press 'R' to restart the game";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		gameOver = true;
		gameOverText.text = " Game \n Over!";
	}

	public bool isGameOver(){
		return gameOver;
	}

	public bool levelUp(){
		if ((getScore () % 100) == 10) {
			return true;
		} else {
			return false;
		}
	}

	public int getScore(){
		return score;
	}

	public bool hasDestroyedEnemy(){
		return destroyedEnemy;
	}

	public void setDestroyEnemy(bool status){
		destroyedEnemy = status;
	}

}
