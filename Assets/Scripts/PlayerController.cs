using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour {

	public float midFrequency;
	public float lowThreshhold;
    public AudioController audioController;
    private Carpet carpet;

    public float acceleration;
    public float maxSpeed;
	private float currentSpeed;
    public GameObject bottomPos;
    public GameObject topPos;

    public bool debug = true;

    private bool allowInput = true;

    void Start() { carpet = GetComponentInChildren<Carpet>(); }
	
	void FixedUpdate ()
	{
        if (allowInput) {
            setAcceleration();
            float newY = Mathf.Clamp(transform.position.y + currentSpeed * Time.fixedDeltaTime, bottomPos.transform.position.y, topPos.transform.position.y);

            transform.position = new Vector3(transform.position.x, newY, 0);
        }
	}

    private void setAcceleration() {
        float currentFrequency = audioController.getPitch();
        float debugInput = Input.GetAxis("Vertical");

        if ((currentFrequency > midFrequency || (debug && debugInput> 0)) && transform.position.y < topPos.transform.position.y) {
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
            AudioManager.instance.musicManager.setThemePitch(2);
            carpet.switchFrequency(2);
        } else if (((currentFrequency < midFrequency && currentFrequency > lowThreshhold) || (debug && debugInput < 0))  && transform.position.y > bottomPos.transform.position.y) {
            currentSpeed = Mathf.Clamp(currentSpeed - acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
            AudioManager.instance.musicManager.setThemePitch(0);
            carpet.switchFrequency(0);
        } else {
            AudioManager.instance.musicManager.setThemePitch(1);
            carpet.switchFrequency(1);
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

    public void enableInput(bool enable) { allowInput = enable; }
}
