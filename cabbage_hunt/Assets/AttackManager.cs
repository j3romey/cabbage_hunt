using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Constraints;

public class AttackManager : MonoBehaviour {

	public GameObject BASE_OBJECT;

	public enum TYPE
	{
		PlayerAttack, EnemyAttack
	}
	//public Animator animator;
	public GameObject[] Attacks;
	public TYPE type;

	void Start(){
		foreach (GameObject attack in Attacks) {
			switch (type) {
			case TYPE.PlayerAttack:
				attack.layer = LayerMask.NameToLayer("PlayerAttack");
				break;

			case TYPE.EnemyAttack:
				attack.layer = LayerMask.NameToLayer("EnemyAttack");
				break;

			default:
				break;
			}
		}
	}

	void Update(){
		/*if (animator.GetCurrentAnimatorStateInfo (0).IsName ("chan_attack_1")) {
			enableAttack (0);
		} else {
			disableAttack (0);
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("chan_attack_2")) {
			enableAttack (1);
		} else {
			disableAttack (1);
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("chan_attack_3")) {
			enableAttack (2);
		} else {
			disableAttack (2);
		}*/
	}	
	public void enableAttack(int num){
		Attacks [num].SetActive (true);
	}

	public void disableAttack(int num){
		Attacks [num].SetActive (false);
	}

	public void destroy(){
		Destroy (transform.parent.gameObject);
		//Destroy (gameObject);
	}

	public void disableAllColliders(){
		BASE_OBJECT.layer = LayerMask.NameToLayer("Dead");
	}

}