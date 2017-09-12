using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public enum STATUS{
		ALIVE, DEAD, POISON, STUNNED, BURNED
	}


	public STATUS status;
	public float health;
	public float damage;
	public int points; 

	private Spawner spawner;

	void Start(){
		spawner = gameObject.GetComponent<Spawner>();
		if (spawner == null) {
			Debug.Log ("NO SPAWNER ATTACHED TO ENEMY: CANNOT PRINT DAMAGE VALUES");
		} else {
			Debug.Log ("Spawner Attached");
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (health <= 0 && status != STATUS.DEAD) {
			die ();
		}
	}

	void die(){
		GameMaster.GM.score.updateScore(points);
		status = STATUS.DEAD;
		Destroy (this.gameObject, 0.50f);
	}

	public void takeDamage(int i){
		Spawner spawner = gameObject.GetComponent<Spawner> (); 

		spawner.spawnDamage (i);

		health -= i;

		if (health < 0) {
			health = 0;
		}
	}
}
