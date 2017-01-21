using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float midFrequency;
	public float lowThreshhold;
    public AudioController audioController;

    public float speed;
	private float currentSpeed;
    public GameObject bottomPos;
    public GameObject topPos;

    public bool debug = true;
	
	void FixedUpdate ()
	{
        currentSpeed = debug ? getDebugInput() : getPitchInput();
		transform.position = transform.position + new Vector3(0, currentSpeed * Time.fixedDeltaTime, 0);
	}

    private float getPitchInput() {
        float currentFrequency = audioController.getPitch();

        if (currentFrequency > midFrequency && transform.position.y < topPos.transform.position.y) {
            return speed;
        } else if (currentFrequency < midFrequency && currentFrequency > lowThreshhold && transform.position.y > bottomPos.transform.position.y) {
            return -speed;
        } else {
            return 0;
        }
    }

    private float getDebugInput() {
        if (Input.GetAxis("Vertical") > 0 && transform.position.y < topPos.transform.position.y) {
            return speed;
        } else if (Input.GetAxis("Vertical") < 0 && transform.position.y > bottomPos.transform.position.y) {
            return -speed;
        } else {
            return 0;
        }
    }

}
