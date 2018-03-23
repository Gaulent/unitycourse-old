using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start() {
		myLaneSpawner = getMyLaneSpawner();
		animator = gameObject.GetComponent<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		
	}
	
	void Update() {
		if (isAttackerAheadInLane())
			animator.SetBool("isAttacking", true);
		else
			animator.SetBool("isAttacking", false);
	}
	
	Spawner getMyLaneSpawner () {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
		
		foreach (Spawner thisSpawner in spawners) {
			if(gameObject.transform.position.y == thisSpawner.transform.position.y)
				return thisSpawner;
		}
		Debug.LogError("Can't find spawner in lane");
		return null;
	}
	
	private void FireGun() {
		GameObject newProjectile = Instantiate (projectile, transform.Find("Gun").position, Quaternion.identity) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
	}
	
	bool isAttackerAheadInLane() {
	
		// No hay enemigos
		if(myLaneSpawner.transform.childCount <= 0)
			return false;
			
		// Hay enemigos delante
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		
		// Hay enemigos, pero todos detras
		return false;
	}
}
