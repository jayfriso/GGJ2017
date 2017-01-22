using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMover : MonoBehaviour {

	public float speed;
	float playerYPos;
	float initialYPos;
	public float acceleration;
	public float minYSpeed;
	public float maxYSpeed;

	void Start ()
	{
       	initialYPos = transform.position.y;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (-speed, GetComponent<Rigidbody2D> ().velocity.y - acceleration, 0);
	}

	void FixedUpdate ()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerYPos = player.transform.position.y;

		if (playerYPos > transform.position.y) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (-speed, GetComponent<Rigidbody2D> ().velocity.y + acceleration, 0);
//			transform.position = new Vector3(transform.position.x, transform.position.y + acceleration, transform.position.z);
		} else if (playerYPos < transform.position.y) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (-speed, GetComponent<Rigidbody2D> ().velocity.y - acceleration, 0);
//			transform.position = new Vector3(transform.position.x, transform.position.y - acceleration, transform.position.z);
		}
		
	}
}
