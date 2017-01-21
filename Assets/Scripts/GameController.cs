using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject obstacle;
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
			Instantiate (obstacle, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds (spawnWaitTime);
		}
	}
}
