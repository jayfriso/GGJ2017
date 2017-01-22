using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject StraightSpirit;
	public GameObject WavySpirit;
	public GameObject ChasingSpirit;
	public GameObject[] spiritsArray = new GameObject[3];

	public Vector2 spawnCoordinates;

	float startWaitTime;
	float shortSpawnGapTime;
	float mediumSpawnGapTime;
	float longSpawnGapTime;
	float lvlTransitionGap;

	public int lvlOneMaxScore;
	public int lvlTwoMaxScore;
	public int lvlThreeMaxScore;
	public int score;

	public bool isDead = false;

	void Start () {
		StartCoroutine (SpawnWaves());
		score = GameManager.instance.getScore();
		lvlTransitionGap = 5.0f;
	}

	GameObject pickRandomSpirit ()
	{
		int random = Random.Range(0,3);
		return spiritsArray[random];
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWaitTime);

		while (true) {

			while (score <= lvlOneMaxScore && !isDead) {
				shortSpawnGapTime = Random.Range (1.5f, 2.5f);

				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (StraightSpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (shortSpawnGapTime);
				score = GameManager.instance.getScore ();
			}

			if (!isDead) {
				yield return new WaitForSeconds (lvlTransitionGap);
			}

			while (score > lvlOneMaxScore && score <= lvlTwoMaxScore && !isDead) {
				mediumSpawnGapTime = Random.Range (2.5f, 4.0f);

				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (WavySpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (mediumSpawnGapTime);
				score = GameManager.instance.getScore ();
			}

			if (!isDead) {
				yield return new WaitForSeconds (lvlTransitionGap);
			}

			while (score > lvlTwoMaxScore && score <= lvlThreeMaxScore && !isDead) {
				longSpawnGapTime = Random.Range (4.0f, 5.0f);
				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (ChasingSpirit, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (longSpawnGapTime);
				score = GameManager.instance.getScore ();
			}

			while (score > lvlThreeMaxScore && !isDead) {
				mediumSpawnGapTime = Random.Range (1.0f, 4.0f);

				Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
				Instantiate (pickRandomSpirit(), spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (mediumSpawnGapTime);
				score = GameManager.instance.getScore ();
			}

			if (!isDead) {
				yield return new WaitForSeconds (lvlTransitionGap);
			}



			while (isDead) {
				Debug.Log("i'm still dead");
				yield return null;
			}

		}	
	}
}
