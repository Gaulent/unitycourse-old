using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 400f;
	public GameObject laserPrefab;
	public float laserSpeed = 10f;
	public float firingRate = 0.5f; // Shots per Second
	
	void OnTriggerEnter2D (Collider2D col) {
		Laser projectile = col.gameObject.GetComponent<Laser>();
		if(projectile) {
			health -= projectile.GetDamage();
			Debug.Log ("Enemy hit.");
			projectile.Hit();
			if(health<=0)
				Destroy (gameObject);
		}
	}
	
	void Update() {
		
		// Probabilidad de disparo en un frame concreto.
		float probability = Time.deltaTime * firingRate;
		
		// Prueba de probabilidad [0,1]
		if(Random.value < probability) {
			Fire ();
		}
	}
	
	void Fire() {
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0,-laserSpeed,0);
	}
	/*
	void Start() {
		InvokeRepeating("Fire", 0.000001f, firingRate*Time.deltaTime*Random.value);
		//Debug.Log(Time.deltaTime);
		//Debug.Log();
	}*/
}
