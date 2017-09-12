using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public enum STATUS{
		ALIVE, DEAD, POISON, STUNNED, BURNED
	}

	public int MAX_HEALTH;
	public int MIN_HEALTH;
	public int MAX_MANA;
	public int MIN_MANA;
	public int MAX_DAMAGE;
	public int MIN_DAMAGE;
	public STATUS status;

	public int health;
	public int mana;

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

	public void damage(int value){
		int temp_health = health - value;
		if (temp_health < MIN_HEALTH){
			health = MIN_HEALTH;
		}else{
			health = temp_health;
		}
	}

	public void heal(int value){
		int temp_health = health + value;
		if(temp_health > MAX_HEALTH){
			health = MAX_HEALTH;
		}else{
			health = temp_health;
		}
	}

	public void updateMana(int value){
		int temp_mana = mana + value;
		if(temp_mana > MAX_MANA){
			mana = MAX_MANA;
		}
		else if (temp_mana < MIN_MANA){
			mana = MIN_MANA;
		}else{
			mana = temp_mana;
		}
	}
}
