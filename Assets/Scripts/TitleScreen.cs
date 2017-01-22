using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {
    private AudioController audioController;
    public float startMidPitch;
    public float startLowCutoff;
    public float startDelay = 3f;
    private bool startable = false;
    void Start() {
        audioController = GetComponentInChildren<AudioController>();
        StartCoroutine(initiateDelay());
    }

	// Update is called once per frame
	void Update () {
        float pitch = audioController.getPitch();

        if (pitch<startMidPitch && pitch > startLowCutoff && startable) {
            GameManager.instance.firstStart();
        }
	}

    private IEnumerator initiateDelay() {
        yield return new WaitForSeconds(startDelay);
        startable = true;
        yield return null;
    }
    
}
