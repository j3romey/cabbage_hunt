using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Constraints;

public class PlayerAttackManager : MonoBehaviour {

	public Animator animator;
	public GameObject[] Attacks;

	void Update(){
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("chan_attack_1")) {
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
		}
	}	
	public void enableAttack(int num){
		Attacks [num].SetActive (true);
	}

	public void disableAttack(int num){
		Attacks [num].SetActive (false);
	}
		
}
