using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

	public enum STATE{
		dead,		// 0
		idle, 		// 1
		walking, 	// 2
		attacking,  // 3
		hit,  		// 4
	}

	public Animator animator;
	private Rigidbody2D body;

	private bool face_right;

	public STATE state;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		state = STATE.idle;
		face_right = true;
	}
	
	// Update is called once per frame
	void Update () {

		flip ();

		if (Input.GetKeyDown (KeyCode.C)) {
			state = STATE.idle;
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			state = STATE.walking;
			body.velocity = new Vector2(2, body.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			state = STATE.walking;
			body.velocity = new Vector2(-2, body.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			state = STATE.attacking;
		}


		switch(state){
			case STATE.idle:
				animator.SetInteger ("State", 1);
				break;
			case STATE.walking:
				animator.SetInteger ("State", 2);
				
				break;
			case STATE.attacking:
				animator.SetInteger ("State", 3);
				break;
			default:
				break;
		}
	}

	public void flip(){
		if(body.velocity.x > 0){
			if(face_right == false){
				face_right = true;
			}

			if(Mathf.Round(transform.eulerAngles.y) != 0){
				transform.Rotate(new Vector3(0,10,0));
			}

		}else if(body.velocity.x < 0){
			if(face_right == true){
				face_right = false;
			}

			if(Mathf.Round(transform.eulerAngles.y) != 180){
				transform.Rotate(new Vector3(0,-10,0));
			}
		}else{
			if(face_right){
				if(Mathf.Round(transform.eulerAngles.y) != 0){
					transform.Rotate(new Vector3(0,10,0));
				}
			}else{
				if(Mathf.Round(transform.eulerAngles.y) != 180){
					transform.Rotate(new Vector3(0,-10,0));
				}
			}
		}
	}
}
