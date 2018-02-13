using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 400f;

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
}
