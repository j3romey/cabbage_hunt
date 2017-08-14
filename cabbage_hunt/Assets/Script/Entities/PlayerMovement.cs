using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {

	public Animator animator;
	public GroundCheck groundCheck;

	private Rigidbody2D body;

	private float movement;
	private bool face_right;
	public float speed;
	public float jump;

	private Boolean attacking;
	private Boolean grounded;
	private Boolean jumped;
	private float nextAttack;
	private float attackDelay;
	private int attackState;
	private float timePassed;

	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();

		attackState = 0;
		attackDelay = 0.275f;
		timePassed = 0f;

		face_right = true;
		attacking = false;
		jumped = false;
		grounded = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// attack timer reset or not should move to a different script?
		if (attacking) {
			timePassed += Time.deltaTime;
			if (timePassed > attackDelay) {
				animator.SetBool ("Attacking", false);
				timePassed = 0f;
				attacking = false;
			}
		}

		if (groundCheck.update () < 0.7f) {
			grounded = true;
			jumped = false;
		}
			
		//Debug.Log(Input.GetAxis("Horizontal"));
		movement = Input.GetAxis("Horizontal");
		flip();

		animator.SetFloat ("GroundDist", groundCheck.update ());
		if (attacking) {
			body.velocity = new Vector2(movement* speed/4, body.velocity.y);
		} else {
			body.velocity = new Vector2(movement* speed, body.velocity.y);
		}

		animator.SetFloat ("MoveSpeed", Mathf.Abs (body.velocity.x));
		animator.SetFloat ("FallingSpeed",(body.velocity.y));

		// jump button
		if (Input.GetKeyDown ("space")) {

			if (grounded && !jumped) {
				body.velocity = new Vector2 (body.velocity.x, jump);
				grounded = false;
				jumped = true;
			} else if (!grounded && jumped) {
				body.velocity = new Vector2 (body.velocity.x, jump);
				jumped = false;
			}
		}


		// attack button
		if (Input.GetKeyDown (KeyCode.Z)) {
			attacking = true;
			//animator.SetInteger ("AttackState", attackState);
			animator.SetBool ("Attacking", true);
			timePassed = 0;
		}

	}

	// paper mario effect
	public void flip(){
		if(movement > 0){
			if(face_right == false){
				face_right = true;
			}
			
			if(Mathf.Round(transform.eulerAngles.y) != 0){
				transform.Rotate(new Vector3(0,10,0));
			}
				
		}else if(movement < 0){
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
