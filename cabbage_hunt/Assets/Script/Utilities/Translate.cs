using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x + Random.Range (-0.5f, 0.5f), transform.position.y + Random.Range (-0.5f, 0.5f), transform.position.z); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.up * Time.deltaTime * speed, Space.World);
	}
}
