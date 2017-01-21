using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance = null;

    public MusicManager musicManager;
    public GameAudioManager gameAudioManager;

    public AudioMixer mainMixer;

    private float baseLevelDecibelLevel = -40;

    //Awake is always called before any Start functions
    void Awake() {
        //Check if instance already exists
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public enum AudioType{ Sound, Music}

    //Setting the audio level for sound effects or music
    public void setSoundEffectsIntensity(float volume) { mainMixer.SetFloat("EffectsVol", volume); }
    public void setMusicIntensity(float volume) { mainMixer.SetFloat("MusicVol", volume); }
}
