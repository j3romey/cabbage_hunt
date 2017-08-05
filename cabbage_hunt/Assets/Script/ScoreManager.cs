using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int newScore;
	public Text scoreDisplay;

	int score = 0;
	int maxLength = 10;

	public void updateScore(int newScore){
		calculateScore (newScore);
		displayScore ();
		Debug.Log (score);
	}

	void calculateScore(int points){
		if (score + points < 0) {
			if (points < 0) {
				score = 0;
			}else {
				score = int.MaxValue;
			}
		}else {
			score += points;
		}
	}

	void displayScore(){
		string temp = score.ToString ();
		scoreDisplay.text = temp.PadLeft(temp.Length + (maxLength - temp.Length), '0');
	}
}
