using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public enum STATUS{
		ALIVE, DEAD, POISON, STUNNED, BURNED
	}

	public int MAX_HEALTH;
	public int MIN_HEALTH;
	public int MAX_DAMAGE;
	public int MIN_DAMAGE;
	public STATUS status;
	public int health;
	public int damage;
	

	public void updateHealth(int value){
		int temp_health = health + value;
		if(temp_health > MAX_HEALTH){
			health = MAX_HEALTH;
		}
		else if (temp_health < MIN_HEALTH){
			health = MIN_HEALTH;
		}else{
			health = temp_health;
		}
	}

	public void updateDamage(int value){
		if(value > MAX_DAMAGE){
			damage = MAX_DAMAGE;
		}else if (value < MIN_DAMAGE){
			damage = MIN_DAMAGE;
		}else{
			damage = value;
		}
	}
}
