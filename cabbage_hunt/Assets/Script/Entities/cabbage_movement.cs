using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbage_movement : MonoBehaviour {

	private bool ALIVE;
	private Quaternion ROTATION;
	private Vector3 DIRECTION, axis, position;
	private float SPEED, MAGNITUDE, FREQUENCY;
	public float min_speed;
	public float max_speed;
    public float min_magnitude;
	public float max_magnitude;
    public float min_frequency;
	public float max_frequency;
	public float min_angle;
	public float max_angle;
	 
	void Start () {
		//TODO: create alve thing
		ALIVE = true;
		float temp = Random.Range(min_angle, max_angle);
		transform.rotation =  Quaternion.Euler(0, 0, temp);
		ROTATION = transform.rotation;
		DIRECTION = new Vector3(-1, 0, 0);
		MAGNITUDE = Random.Range(min_magnitude, max_magnitude);
		SPEED = Random.Range(min_speed, max_speed);
		FREQUENCY = Random.Range(min_frequency, max_frequency);
		position = transform.position;
        axis = new Vector3(0,1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(ALIVE){
			position += DIRECTION * Time.deltaTime * SPEED;
        	transform.position = position + axis * Mathf.Sin (Time.time * FREQUENCY) * MAGNITUDE;
			// bring rotation here??

			if(ROTATION != transform.rotation){
				ALIVE = false;
			}
		}else{
			Rigidbody2D temp = gameObject.GetComponent<Rigidbody2D>( );
			temp.gravityScale = 1.0f;
		}
	}
}
