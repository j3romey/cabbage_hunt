using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour {

	[Range(0.0f,1.0f)]
	public float testAmount = 0.05f;
	[Range(0.0f,1.0f)]
	public float testLength = 0.1f;

	//public ScoreManager test_score;
	public CameraShake test_shake;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			Debug.Log ("space key was pressed");
			//test_score.updateScore (217651293);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			Debug.Log ("Shake");
			test_shake.Shake (testAmount, testLength);
		}
	}
}
