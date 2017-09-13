using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundCheck : MonoBehaviour {

	public float groundDistance;
	int layer_mask;


	void Start(){
		layer_mask = LayerMask.GetMask("Ground");
	}


	public float update(){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 9999, layer_mask);
		if (hit.collider != null) {
			return hit.distance;
		} else {
			return -1;
		}
	}

	public void enable(){

	}

	public void disable(){

	}
}
