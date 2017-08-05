using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SIMPLE CAMERA SHAKE SCRIPT
public class CameraShake : MonoBehaviour {

	public Camera mainCam;
	[Range(0.0f,1.0f)]
	public float testAmount = 0.05f;
	[Range(0.0f,1.0f)]
	public float testLength = 0.1f;

	Vector3 originalPosition;
	float shakeAmount = 0;

	void Awake(){
		if (mainCam == null) {
			mainCam = Camera.main;
		}

		originalPosition = Camera.main.transform.position;
	}

	// testing code
	void Update(){
		if (Input.GetKeyDown (KeyCode.T)) {
			Shake (testAmount, testLength);
		}
	}

	public void Shake(float amount, float length){
		shakeAmount = amount;
		InvokeRepeating ("BeginShake", 0, 0.01f);
		Invoke ("StopShake", length);
	}

	void BeginShake(){
		if (shakeAmount > 0) {

			Vector3 camPos = mainCam.transform.position;

			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

			camPos.x += offsetX;
			camPos.y += offsetY;

			mainCam.transform.position = camPos;
		}
	}

	void StopShake(){
		CancelInvoke ("BeginShake");
		mainCam.transform.position = originalPosition;
	}
}
