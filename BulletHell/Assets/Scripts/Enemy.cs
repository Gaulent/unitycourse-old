using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 400f;
	public GameObject laserPrefab;
	public float laserSpeed = 10f;
	public float firingRate = 0.5f; // Shots per Second
	public int scoreValue = 150;
	ScoreKeeper score;
	public AudioClip shoot_sfx;
	public AudioClip destroyed_sfx;
	private Gun[] guns;
	
	void Start () {
		score = FindObjectOfType<ScoreKeeper>();
		guns = GetComponentsInChildren<Gun>();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		Laser projectile = col.gameObject.GetComponent<Laser>();
		if(projectile) {
			health -= projectile.GetDamage();
			//Debug.Log ("Enemy hit.");
			projectile.Hit();
			if(health<=0) {
				Destroy (gameObject);
				score.Score(scoreValue);
				AudioSource.PlayClipAtPoint(destroyed_sfx, transform.position, 1f);
			}
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

		foreach(Gun gun in guns) {
			GameObject laser = Instantiate(laserPrefab, gun.transform.position, gun.transform.rotation) as GameObject;

			laser.GetComponent<Rigidbody2D>().velocity = gun.aim*laserSpeed;
			laser.GetComponent<SpriteRenderer>().color = Color.cyan;
		}
		AudioSource.PlayClipAtPoint(shoot_sfx, transform.position, 0.02f);
	}

}
