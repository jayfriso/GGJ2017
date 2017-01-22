using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

    public Text scoreText;
    public GameObject gameOverScreen;
    private string scoreString = "SCORE: ";


	// Use this for initialization
	void Start () {
        setScoreText(0);
	}
	
	public void setScoreText(int score) {
        scoreText.text = scoreString + score;
    }

    public void showGameOver(bool show) {
        gameOverScreen.SetActive(show);
    }
}
