using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit.Framework.Constraints;

public class EnemyMovement : MonoBehaviour {

	public enum STATE{
		dead,		// 0
		idle, 		// 1
		moving, 	// 2
		attacking,  // 3
		hit,  		// 4
	}
		
	public Enemy enemy;  // rename later?
	public Animator animator;
	private Rigidbody2D body;
	private int layer_mask;
	private bool face_right;
	private Vector3 origin;

	public STATE state;
	public float attack_range;
	public float move_distance;
	public float speed;
	public float idle_delay;
	private float time_passed;


	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy>();
		body = GetComponent<Rigidbody2D>();
		layer_mask = LayerMask.GetMask("Player");
		state = STATE.idle;
		face_right = true;
		time_passed = 0f;
		origin = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		flip ();
		// variables to determine state
		if (state == STATE.idle) {
			time_passed += Time.deltaTime;
			if (time_passed > idle_delay) {
				state = STATE.moving;
				time_passed = 0;
			}
		}

		if (playerInRange ()) {
			state = STATE.attacking;
		} else if (state != STATE.idle) {
			state = STATE.moving;
		}

		if (enemy.status == Enemy.STATUS.DEAD) {
			state = STATE.dead;
		}
			
		switch(state){
			case STATE.dead:
				animator.SetInteger ("State", 0);
				break;
			case STATE.idle:
				animator.SetInteger ("State", 1);
				break;
			case STATE.moving:
				animator.SetInteger ("State", 2);
				move ();
				break;
			case STATE.attacking:
				attack ();
				break;
			case STATE.hit:
				hit ();
				break;

			default:
				break;
		}
	}

	// Enemy Methods

	public void hit(){
		animator.SetTrigger ("Hit");
	}

	// assign different movements here.
	public void move(){
		if (face_right) {
			right ();
			if ( transform.position.x > (origin.x + move_distance) ) {
				left();
			}
		} 
		// going left (negative x)
		else {
			left ();
			if (transform.position.x < (origin.x - move_distance) ) {
				right ();
			}
		}

	}

	public void left(){
		body.velocity = new Vector2 (-speed, body.velocity.y);
	}

	public void right(){
		body.velocity = new Vector2 (speed, body.velocity.y);
	}

	public void attack(){
		body.velocity = new Vector2 (0, 0);
		animator.SetTrigger ("Attack");
		state = STATE.idle;
		time_passed = 0;
	}


	public void die(){
		body.velocity = new Vector2 (0, 0);
		animator.SetTrigger ("Dead");
	}


	public Boolean playerInRange(){
		
		RaycastHit2D hit;
		// determines which direction they raycast should go
		if (face_right) {
			hit = Physics2D.Raycast (transform.position, -Vector2.left, 9999, layer_mask);
		} else {
			hit = Physics2D.Raycast (transform.position, Vector2.left, 9999, layer_mask);
		}

		//determines if raycast hit is within range
		if (hit.collider != null) {
			float distance = Mathf.Abs (hit.point.x - transform.position.x);
			if (distance < attack_range) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	// used to flip the sprite paper mario style
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
