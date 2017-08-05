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

	Boolean attacking;
	private float nextAttack;
	private float attackDelay;
	private int attackState;
	private float timePassed;

	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		face_right = true;

		attackState = 0;
		attackDelay = 0.25f;
		timePassed = 0f;
		attacking = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (attacking) {
			timePassed += Time.deltaTime;
			if (timePassed > attackDelay ) {
				//attackState = 0;
				//animator.SetInteger ("AttackState", 0);
				animator.SetBool ("Attacking", false);
				timePassed = 0f;
			}
		}


		//Debug.Log(Input.GetAxis("Horizontal"));
		movement = Input.GetAxis("Horizontal");
		flip();

		animator.SetFloat ("GroundDist", groundCheck.update ());

		body.velocity = new Vector2(movement* speed, body.velocity.y);
		animator.SetFloat ("MoveSpeed", Mathf.Abs (body.velocity.x));
		animator.SetFloat ("FallingSpeed",(body.velocity.y));

		if (Input.GetKeyDown ("space")) {
			body.AddForce (transform.up * 350);
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			attacking = true;
			//animator.SetInteger ("AttackState", attackState);
			animator.SetBool ("Attacking", true);
			timePassed = 0;
		}

	}


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
