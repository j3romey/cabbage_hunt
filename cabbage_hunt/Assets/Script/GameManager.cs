using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public ScoreManager Score;

	void Awake(){
		// makes sure that its instantiated and another instance is not something else
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
