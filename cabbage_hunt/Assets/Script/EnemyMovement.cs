using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit.Framework.Constraints;

public class EnemyMovement : MonoBehaviour {

	public enum STATE{
		dead,		// 0
		idle, 		// 1
		walking, 	// 2
		attacking,  // 3
		hit,  		// 4
	}

	public enum DIRECTION{
		left, right
	}

	public Animator animator;
	private Rigidbody2D body;
	private int layer_mask;
	private bool face_right;

	public STATE state;
	public DIRECTION direction;
	public float player_distance;
	public float move_distance;
	public float speed;


	//continous vs not

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		state = STATE.walking;
		face_right = true;
		layer_mask = LayerMask.GetMask("Player");
	}
	
	// Update is called once per frame
	void Update () {
		flip ();

		// use the move distance
		if (playerInRange ()) {
			//direction = DIRECTION.right;
			state = STATE.attacking;
		} else {
			state = STATE.walking;
		}
			
		switch(state){
			case STATE.idle:
				animator.SetInteger ("State", 1);
				break;
			case STATE.walking:
				animator.SetInteger ("State", 2);
				if (direction == DIRECTION.left) {
					left ();
				} else {
					right ();
				}
				break;
			case STATE.attacking:
				attack ();
				break;
			default:
				break;
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
		if (direction == DIRECTION.left) {
			direction = DIRECTION.right;
		} else {
			direction = DIRECTION.left;
		}
	}

	public Boolean playerInRange(){
		Boolean same_x = Mathf.Abs(GameMaster.GM.player.transform.position.x - transform.position.x) < player_distance;
		Boolean same_y = Mathf.Abs(GameMaster.GM.player.transform.position.y - transform.position.y) < 1f;
		return same_x && same_y;
	}

	public void flip(){
		if(body.velocity.x > 0){
			if(face_right == false){
				face_right = true;
				//direction = DIRECTION.right;
			}

			if(Mathf.Round(transform.eulerAngles.y) != 0){
				transform.Rotate(new Vector3(0,10,0));
			}

		}else if(body.velocity.x < 0){
			if(face_right == true){
				face_right = false;
				//direction = DIRECTION.left;
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
