using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1f;
	public float damage = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D c2d) {
		GameObject target = c2d.gameObject;
		if (target.GetComponent<Attacker>()) {
			Health health = target.GetComponent<Health>();
			if(health) {
				health.DealDamage(damage);
				Destroy(gameObject);
			}
		}
	}
}
