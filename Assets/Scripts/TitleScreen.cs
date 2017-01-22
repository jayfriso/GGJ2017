using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {
    private AudioController audioController;
    public float startMidPitch;
    public float startLowCutoff;
	
    void Start() {
        audioController = GetComponentInChildren<AudioController>();
    }

	// Update is called once per frame
	void Update () {
        float pitch = audioController.getPitch();

        if (pitch<startMidPitch && pitch > startLowCutoff) {
            GameManager.instance.firstStart();
        }
	}

    
}
