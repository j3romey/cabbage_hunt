using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D body;
	private float movement;
	private bool face_right;
	public float speed;

	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		face_right = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Input.GetAxis("Horizontal"));
		movement = Input.GetAxis("Horizontal");
		
		flip();

		body.velocity = new Vector2(movement* speed, body.velocity.y);

		if(Input.GetKeyDown("space")){
			body.AddForce(transform.up * 350);
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
