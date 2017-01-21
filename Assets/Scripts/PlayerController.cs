using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayerController : MonoBehaviour {

	public float midFrequency;
	public float lowThreshhold;
    public AudioController audioController;

    public float acceleration;
    public float maxSpeed;
	private float currentSpeed;
    public GameObject bottomPos;
    public GameObject topPos;

    public bool debug = true;
	
	void FixedUpdate ()
	{
        currentSpeed = getSpeed();
		transform.position = transform.position + new Vector3(0, currentSpeed * Time.fixedDeltaTime, 0);
	}

    private void setAcceleration() {
        float currentFrequency = audioController.getPitch();
        float debugInput = Input.GetAxis("Vertical");

        if ((currentFrequency > midFrequency || (debug && debugInput> 0)) && transform.position.y < topPos.transform.position.y) {
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
        } else if (((currentFrequency < midFrequency && currentFrequency > lowThreshhold) || (debug && debugInput < 0))  && transform.position.y > bottomPos.transform.position.y) {
            currentSpeed = Mathf.Clamp(currentSpeed - acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
        }
    }

    private float getSpeed() {
        float currentFrequency = audioController.getPitch();
        float debugInput = Input.GetAxis("Vertical");

        if ((currentFrequency > midFrequency || (debug && debugInput > 0)) && transform.position.y < topPos.transform.position.y) {
            return maxSpeed;
        } else if (((currentFrequency < midFrequency && currentFrequency > lowThreshhold) || (debug && debugInput < 0)) && transform.position.y > bottomPos.transform.position.y) {
            return -maxSpeed;
        } else {
            return 0;
        }
    }

=======
[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public Boundary boundary;
	public GameObject startPos;
	public GameObject endPos;

	public float midPitch;
	public float lowThreshhold;
	public float speed;
	private float currentSpeed;
	public AudioController audioController;
	void FixedUpdate ()
	{
		
	}
	
	
	void Update ()
	{
		float currentFrequency = audioController.getPitch ();
		if (currentFrequency > midPitch) {
			currentSpeed = speed;
			
		} else if (currentFrequency < midPitch && currentFrequency > lowThreshhold) {
			currentSpeed = -speed;
		} else {
			currentSpeed = 0;
		}

		transform.position = transform.position + new Vector3(0, currentSpeed * Time.fixedDeltaTime, 0);

	}
>>>>>>> 1541999204704662cacf7e6b5573c32748bbf6fd
}
