using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool isGameOver = false;
    private GameUI gameUI;

    private int score = 0;

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
       
    }

    public void restartGame() {
        //TODO: restart level stuff
        score = 0; gameUI.setScoreText(score);
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.enableInput(true); //reenable the player
        gameUI.showGameOver(false); //disable the gameoverScreen
        isGameOver = false; //set the game over flag
    }

    public int getScore() { return score; }
    public void addPoint() {
        score++;
        gameUI.setScoreText(score);
    }

    public void gameOver() {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.enableInput(false); //disable the player input
        clearEnemies();
        gameUI.showGameOver(true);
        isGameOver = true;
        StartCoroutine(waitForRestart());
    }

    //Destroys all the enemies currently in the scene
    private void clearEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) { DestroyObject(enemy); }
    }

    private IEnumerator waitForRestart() {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        AudioController audioController = player.audioController;
        
        //wait for the space button or a high pitch sound to be made
        while (!(Input.GetButtonDown("Restart") || audioController.getPitch() > player.midFrequency)) { yield return null;}
        restartGame();
        yield return null;
    }
}
