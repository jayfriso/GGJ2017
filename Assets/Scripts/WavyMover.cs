using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyMover : MonoBehaviour {

	public float speed;
	public float frequency;
	public float amplitude;
	float initialYPos;

	void Start ()
	{
       	initialYPos = transform.position.y;
		GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
	}

	void Update () 
	{
		transform.position = new Vector3(transform.position.x, initialYPos + amplitude * Mathf.Sin(Time.time * frequency), transform.position.z);
	}
}
