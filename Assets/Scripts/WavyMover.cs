using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyMover : MonoBehaviour {

	public float speed;
	float frequency;
	float amplitude;
	float initialYPos;

	void Start ()
	{
		frequency = Random.Range(5.0f, 10.0f);
		amplitude = Random.Range(0.5f, 1.0f);
       	initialYPos = transform.position.y;
		GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
	}

	void Update () 
	{
		transform.position = new Vector3(transform.position.x, initialYPos + amplitude * Mathf.Sin(Time.time * frequency), transform.position.z);
	}
}
