using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

    public GameObject scoreUI;
    public GameObject gameOverScreen;
    private string scoreString = "SCORE: ";

    public GameObject newHighScoreUI;
    public GameObject scoreTextUI;
    private string newHighScoreText = "New High Score!!! \n \n ";
    private string scoreText1 = "Current Score: ";
    private string scoreText2 = "\n \n High Score: ";


    // Use this for initialization
    void Start () {
        setScoreText(0);
	}
	
	public void setScoreText(int score) {

        scoreUI.GetComponent<Text>().text = scoreString + score;
    }

    public void showScoreUI(bool show) {
        scoreUI.SetActive(show);
    }

    public void showGameOver(bool show) {
        gameOverScreen.SetActive(show);
    }

    public void showScoreScreen(bool isHighScore, int score, int highScore) {
        if (isHighScore) {
            scoreTextUI.SetActive(false);
            newHighScoreUI.SetActive(true);
            newHighScoreUI.GetComponent<Text>().text = newHighScoreText + score; 
        } else {
            scoreTextUI.SetActive(true);
            newHighScoreUI.SetActive(false);
            scoreTextUI.GetComponent<Text>().text = scoreText1 + score + scoreText2 + highScore;
        }
    }
}
