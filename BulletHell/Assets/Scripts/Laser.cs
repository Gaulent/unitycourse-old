using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float damage = 100f;

	void Start() {
		GameObject parentGO = GameObject.Find("Bullets");
		if(!parentGO) parentGO = new GameObject("Bullets");
		transform.parent = parentGO.transform;
	}

	public float GetDamage() {
		return damage;
	}
	
	public void Hit() {
		Destroy (gameObject);
	}
}
