using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyMover : MonoBehaviour {

	public float speed;
	public float minFrequency;
	public float maxFrequency;
	public float minAmp;
	public float maxAmp;
	float frequency;
	float amplitude;
	float initialYPos;

	void Start ()
	{
		frequency = Random.Range(minFrequency, maxFrequency);
		amplitude = Random.Range(minAmp, maxAmp);
       	initialYPos = transform.position.y;
		GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
	}

	void Update () 
	{
		transform.position = new Vector3(transform.position.x, initialYPos + amplitude * Mathf.Sin(Time.time * frequency), transform.position.z);
	}
}
