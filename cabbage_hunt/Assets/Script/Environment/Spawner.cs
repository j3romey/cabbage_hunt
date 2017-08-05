using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	private float TIME_PASSED;
	public GameObject prefab;
	public float delay;
	public float amount;

	public List<Transform> spawn_points;
	// Use this for initialization
	void Start () {
		TIME_PASSED = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		TIME_PASSED += Time.deltaTime;

		if(TIME_PASSED > delay){
			TIME_PASSED = 0f;

			int temp = Random.Range(0, spawn_points.Count-1);

			GameObject clone = (GameObject)Instantiate(prefab, spawn_points[temp].transform.position, Quaternion.identity);
		}
		
	}
}
