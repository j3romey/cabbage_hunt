using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour {
	
	public Animator animator;

	private Boolean attacking;
	private float timePassed;
	private float attackDelay;

	// Use this for initialization
	void Start () {
		attacking = false;
		timePassed = 0f;
		attackDelay = 0.275f;
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


		// attack button
		if (Input.GetKeyDown (KeyCode.Z)) {
			attacking = true;
			//animator.SetInteger ("AttackState", attackState);
			animator.SetBool ("Attacking", true);
			timePassed = 0;
		}
	}
}
