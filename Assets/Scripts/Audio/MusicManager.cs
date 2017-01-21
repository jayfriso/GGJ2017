using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : AbstractAudioManager {

    public AudioSource mainTheme; public float mainThemeVolume;
    public float defaultFadeInSpeed = 1f; public float defaultFadeOutSpeed = 1f;

    void Start() { playMainTheme(); }

    public void playMainTheme() { setTrackToFadeIn(mainTheme, mainThemeVolume); }

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
