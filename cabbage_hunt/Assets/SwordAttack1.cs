using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack1 : MonoBehaviour {

	// cabage dies when rotation changes

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
			Rigidbody2D rigidbody2d = other.gameObject.GetComponent<Rigidbody2D> ();
			Debug.Log (rigidbody2d);
			if (rigidbody2d != null) {
				Debug.Log ("added force");
				rigidbody2d.AddForce (transform.right * 500f);
				rigidbody2d.AddTorque (50f);
			}
		}
	}
}
