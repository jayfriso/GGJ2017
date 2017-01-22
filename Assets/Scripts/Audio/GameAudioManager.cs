using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : AbstractAudioManager {

    public AudioSource scream;

    public void playScream() { playOneShotSound(scream, scream.volume); }
}
