using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack1 : MonoBehaviour {

	// cabage dies when rotation changes

	int max_damage;
	int min_damage;

	void Start(){
		max_damage = gameObject.GetComponentInParent<Player> ().MAX_DAMAGE;
		min_damage = gameObject.GetComponentInParent<Player> ().MIN_DAMAGE;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
			Rigidbody2D rigidbody2d = other.gameObject.GetComponent<Rigidbody2D> ();
			Enemy enemy = other.GetComponent<Enemy> ();

			Debug.Log (rigidbody2d);
			if (rigidbody2d != null) {
				Debug.Log ("added force");
				rigidbody2d.AddForce (transform.right * 100f);
				rigidbody2d.AddTorque (50f);

				enemy.takeDamage (DamageGen.higher(min_damage, max_damage));
			}
		}
	}
}
