using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPointsDisplay : MonoBehaviour {

	public Slider slider;
	public Player player;

	// assume that healh = 100 so always integers

	// Update is called once per frame
	void Update () {
		slider.value = player.mana;
	}
}
