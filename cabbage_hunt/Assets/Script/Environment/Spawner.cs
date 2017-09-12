using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public enum TYPE{
		single, repeat, method
	}

	public TYPE type;
	private float TIME_PASSED;
	public GameObject prefab;
	public float delay;

	public List<Transform> spawn_points;
	// Use this for initialization
	void Start () {
		TIME_PASSED = 0f;

		if (type == TYPE.single) {
			int temp = Random.Range (0, spawn_points.Count - 1);
			Instantiate (prefab, spawn_points [temp].transform.position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (type == TYPE.repeat) {
			TIME_PASSED += Time.deltaTime;

			if (TIME_PASSED > delay) {
				TIME_PASSED = 0f;

				int temp = Random.Range (0, spawn_points.Count - 1);

				Instantiate (prefab, spawn_points [temp].transform.position, Quaternion.identity);
			}
		}
	}

	public void spawnDamage (int i){
		
		int temp = Random.Range (0, spawn_points.Count - 1);
	
		GameObject clone = Instantiate (prefab, spawn_points [temp].transform.position , Quaternion.identity);
		Text text = clone.GetComponent<Text>();
		text.text = i.ToString ();
		text.enabled = true;

		Destroy (clone, 2.0f);
	}
}
