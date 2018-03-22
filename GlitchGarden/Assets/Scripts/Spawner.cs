using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in enemies) {
			if (isTimeToSpawn(thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}
	
	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 0.2f);
	}
	
	void Spawn(GameObject enemy) {
		//GameObject lizardPrefab = GameObject.FindObjectOfType<Lizard>();
		GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
		newEnemy.transform.parent = transform;
	}
	bool isTimeToSpawn(GameObject enemy) {
		float timeToSpawn = enemy.GetComponent<Attacker>().seenEverySeconds;
		float spawnsPerSecond = 1/timeToSpawn;
		
		if (Time.deltaTime > timeToSpawn) 
			Debug.LogWarning ("Spawn rate capped by frame rate");
			
		float threshold = spawnsPerSecond * Time.deltaTime / 5; // Por que hay 5 lanes
		
		return (Random.value < threshold);
	}
}
