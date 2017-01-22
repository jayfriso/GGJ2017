using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject StraightSpirit;
	public GameObject WavySpirit;
	public GameObject ChasingSpirit;

	public Vector2 spawnCoordinates;
	public float startWaitTime;
	public float spawnWaitTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWaitTime);
		while (true) {
			Vector2 spawnPosition = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
			Vector2 spawnPosition2 = new Vector2 (spawnCoordinates.x, Random.Range (-spawnCoordinates.y, spawnCoordinates.y));
			Instantiate (StraightSpirit, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds (spawnWaitTime);
			Instantiate (WavySpirit, spawnPosition2, Quaternion.identity);
			yield return new WaitForSeconds (spawnWaitTime);
		}
	}
}
