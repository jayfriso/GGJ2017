using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : AbstractAudioManager {

    public AudioSource[] themes; //Organized of P1L, P1M, P1H, P2L....
    public float themeVolume;
    public float defaultFadeInSpeed = 1f; public float defaultFadeOutSpeed = 1f;
    private int themeIndex = 0; //The base index to start at
    private int currentPitchIndex = 0; //The index for the pitch version
    public float switchTime;
    public bool canSwitch = true;

    void Start() { startMusicTracks(); }

    private void startMusicTracks() {
        for(int i=0; i<9; i++) {
            playLoopingSound(themes[i]);
        }
        setThemePitch(1); //start the base pitch theme
    }

    public void setThemePitch(int pitchIndex) {
        if (pitchIndex != currentPitchIndex && canSwitch) {
            //themes[themeIndex + currentPitchIndex].volume = 0; //Turn off what was playing
            //currentPitchIndex = pitchIndex;
            //themes[themeIndex + currentPitchIndex].volume = themeVolume; //Turn on new version
            StartCoroutine(switchPitches(pitchIndex));
        }
    }

    private IEnumerator switchPitches(int pitchIndex) {
        canSwitch = false; //dont switch again until we fully swtich
        int currentIndex = themeIndex + currentPitchIndex;
        int newIndex = themeIndex + pitchIndex;
        currentPitchIndex = pitchIndex;

        float time = 0f;
        while (time < switchTime) {
            time += Time.deltaTime;
            float ratio = Mathf.Lerp(0, themeVolume, time / switchTime);
            themes[newIndex].volume = ratio;
            themes[currentIndex].volume = 1 - ratio;
            yield return null;
        }
        canSwitch = true;
        yield return null;

    }


    //Helper Functions 

    private void setTrackToFadeIn(AudioSource source, float volume, float fadeInSpeed = 0f) {
        if (fadeInSpeed == 0)
            fadeInSpeed = defaultFadeInSpeed;

        source.volume = 0;
        playLoopingSound(source);
        StartCoroutine(fadeIn(source, volume, fadeInSpeed));
    }

    IEnumerator fadeIn(AudioSource source, float volume, float fadeInSpeed) {
        while (source.volume < volume) {
            source.volume += fadeInSpeed * Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    private void setTrackToFadeOut(AudioSource source, float fadeOutSpeed = 0f) {
        if (fadeOutSpeed == 0)
            fadeOutSpeed = defaultFadeOutSpeed;

        StartCoroutine(fadeOut(source, fadeOutSpeed));
    }

    IEnumerator fadeOut(AudioSource source, float fadeOutSpeed) {
        while (source.volume > 0) {
            source.volume -= fadeOutSpeed * Time.deltaTime;
            yield return null;
        }
        source.Stop();
        yield break;
    }

    public void setSongSwitch(AudioSource sourceFrom, AudioSource sourceTo, float sourceToVolume) {
        setTrackToFadeOut(sourceFrom);
        setTrackToFadeIn(sourceTo, sourceToVolume);

    }
}
