using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float damage = 100f;
	public bool friendly = true;
	
	public float GetDamage() {
		return damage;
	}
	
	public bool getFriendly() {
		return friendly;
	}
	
	
	
	public void Hit() {
		Destroy (gameObject);
	}
}
