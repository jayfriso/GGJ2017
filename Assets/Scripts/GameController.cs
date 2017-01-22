using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject StraightSpirit;
	public GameObject WavySpirit;
	public GameObject ChasingSpirit;

	public Vector2 spawnCoordinates;
	public float startWaitTime;
	public float spawnGapTime;
	public float lvlTransitionGap;

	public int lvlOneMaxScore;
	public int lvlTwoMaxScore;
	public int lvlThreeMaxScore;
	public int score;

	public bool isDead = false;

	void Start () {
		StartCoroutine (SpawnWaves());
		score = GameManager.instance.getScore();
		spawnGapTime = 2.0f;
		lvlTransitionGap = 3.0f;
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWaitTime);

		while (true) {

			while (score <= lvlOneMaxScore && !isDead) {
				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (StraightSpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnGapTime);
				score = GameManager.instance.getScore ();
			}

			if (!isDead) {
				yield return new WaitForSeconds (lvlTransitionGap);
			}

			while (score > lvlOneMaxScore && score <= lvlTwoMaxScore && !isDead) {
				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (WavySpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnGapTime);
				score = GameManager.instance.getScore ();
			}

			if (!isDead) {
				yield return new WaitForSeconds (lvlTransitionGap);
			}

			while (score > lvlTwoMaxScore && score <= lvlThreeMaxScore && !isDead) {
				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (ChasingSpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnGapTime);
				score = GameManager.instance.getScore ();
			}

			if (!isDead) {
				yield return new WaitForSeconds (lvlTransitionGap);
			}

			while (score > lvlThreeMaxScore && !isDead) {
				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (WavySpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnGapTime);
			}

			while (isDead) {
				Debug.Log("i'm still dead");
				yield return null;
			}

		}	
	}
}
