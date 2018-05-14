using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private GameObject[] spawnPoints;
	public Helicopter helicopter;
	public bool spawn = false;

	// Use this for initialization
	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn) {
			ReSpawn();
			spawn = false;
		}
	}
	
	void ReSpawn() {
		GameObject placeToSpawn = spawnPoints[Random.Range(0,spawnPoints.Length)];
		transform.position = placeToSpawn.transform.position;
	}
	
	void OnFindClearArea() {
		Debug.Log("Found Clear Area");
		helicopter.Call();
	}
}


