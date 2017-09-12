using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageGen {
	// a is lower b is higher !!!!!!
	public static int higher(int a, int b){
		int x = Random.Range (a, b);
		int y = Random.Range (a, b);
		return Mathf.Max (x, y);
	}

	public static int lower(int a, int b){
		int x = Random.Range (a, b);
		int y = Random.Range (a, b);
		return Mathf.Min (x, y);
	}

	public static int normal(int a, int b){
		int z = Random.Range (a, b);

		return z;
	}

}
