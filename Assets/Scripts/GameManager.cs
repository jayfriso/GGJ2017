﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool isGameOver = false;
    private GameUI gameUI;

    private int score = 0;
    private int highscore = 0;

    public float restartDelay;

    private GameController gameController;

    public bool isTitleScreen = false;

    private bool isExiting = false;

	// Use this for initialization
	void Awake () {
        //Check if instance already exists
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        gameUI = GetComponentInChildren<GameUI>();
        gameController = GetComponent<GameController>();
        if (isTitleScreen) {
            gameController.isDead = true; //set dead to true so no things will be spawned
            gameUI.showScoreUI(false);
        } else {
            PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.showArrows();
        }       
    }

    void Update() {
        checkForExit();
    }

    private void checkForExit() {
        if (Input.GetButtonDown("Cancel") && !isExiting) {
            StartCoroutine(waitForFullExit());
        }
    }

    private IEnumerator waitForFullExit() {
        isExiting = true;
        float waitTime = 1;
        yield return new WaitForSeconds(waitTime);
        if (Input.GetButton("Cancel")) {
            Debug.Log("QUITTED!!!!");
            Application.Quit();
        } else {
            isExiting = false;
        }
        yield return null;
    }

    public void firstStart() {
        gameController.isDead = false;
        gameUI.showScoreUI(true);       
        AudioManager.instance.musicManager.startMusicTracks();
        SceneManager.LoadScene("MainScene");
    }

    public void restartGame() {
        //TODO: restart level stuff
        AudioManager.instance.musicManager.setThemeSwitch(0);
        score = 0; gameUI.setScoreText(score);
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.GetComponentInChildren<Animator>().SetBool("isDead", false);
        player.enableInput(true); //reenable the player
        player.showArrows();
        gameUI.showGameOver(false); //disable the gameoverScreen
        isGameOver = false; //set the game over flag
        gameController.isDead = false;
    }

    public int getScore() { return score; }
    public void addPoint() {
        score++;
        gameUI.setScoreText(score);
    }

    public void gameOver() {
        AudioManager.instance.gameAudioManager.playScream();
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.GetComponentInChildren<Animator>().SetBool("isDead", true);
        player.enableInput(false); //disable the player input
        clearEnemies();        
        gameUI.showGameOver(true);
        gameUI.showScoreScreen(checkHighScore(), score, highscore);
        isGameOver = true;
        gameController.isDead = true;
        StartCoroutine(waitForRestart());
    }


    //returns if you just got a high score and sets the highscore
    private bool checkHighScore() {
        if (score > highscore) {
            highscore = score;
            return true;
        } else { return false; }
    }

    //Destroys all the enemies currently in the scene
    private void clearEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) { DestroyObject(enemy); }
    }

    private IEnumerator waitForRestart() {
        yield return new WaitForSeconds(restartDelay);
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        AudioController audioController = player.audioController;
        
        //wait for the space button or a high pitch sound to be made
        while (!(Input.GetButtonDown("Restart") || (audioController.getPitch() < player.midFrequency && audioController.getPitch() > player.lowThreshhold))) { yield return null;}
        restartGame();
        yield return null;
    }
}
