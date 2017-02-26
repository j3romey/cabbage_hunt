using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbage_movement : MonoBehaviour {

	private float ran;

	private float move_ran;
	public float MoveSpeed;
    public float min_magnitude;
	public float max_magnitude;
    public float frequency;
    private Vector3 axis;
 
    private Vector3 pos;
	 
	void Start () {
		ran = Random.Range(min_magnitude, max_magnitude);
		move_ran = Random.Range(4, 8);
		pos = transform.position;
         axis = new Vector3(0,1,0);  // May or may not be the axis you want
	}
	
	// Update is called once per frame
	void Update () {
		pos += new Vector3(-1,0,0) * Time.deltaTime * move_ran;
        transform.position = pos + axis * Mathf.Sin (Time.time * frequency) *ran;
	}
}
