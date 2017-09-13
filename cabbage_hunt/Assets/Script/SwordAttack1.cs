using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack1 : MonoBehaviour {

	public enum TYPE
	{
		PlayerAttack, EnemyAttack
	}

	private int max_damage;
	private int min_damage;
	public TYPE type;

	void Start(){
		switch (type) {
		case TYPE.PlayerAttack:
			max_damage = gameObject.GetComponentInParent<Player> ().MAX_DAMAGE;
			min_damage = gameObject.GetComponentInParent<Player> ().MIN_DAMAGE;
			break;

		case TYPE.EnemyAttack:
			max_damage = gameObject.GetComponentInParent<Enemy> ().damage;
			min_damage = gameObject.GetComponentInParent<Enemy> ().damage;
			break;

		default:
			break;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {

		// Enemy Hits Player
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Player player = other.GetComponent<Player> ();

			if (player != null) {
				player.damage (max_damage);
			}
		}

		// Player hits enemy
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
			Rigidbody2D rigidbody2d = other.gameObject.GetComponent<Rigidbody2D> ();
			Enemy enemy = other.GetComponent<Enemy> ();
		 // move this later not here.........

			Debug.Log (rigidbody2d);
			if (rigidbody2d != null) {
				Debug.Log ("added force");
				//rigidbody2d.AddForce (transform.right * 100f); do the force thing on the enemy side.
				//rigidbody2d.AddTorque (50f);
				//test.hit ();

				enemy.takeDamage (DamageGen.higher(min_damage, max_damage));
			}
		}
	}

}
