using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	public LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D c2d) {
		Debug.Log ("OnTriggerEnter2D --> " + c2d.ToString());
	}
	
	void OnCollisionEnter2D (Collision2D c2d) {
		Debug.Log ("OnCollisionEnter2D --> " + c2d.ToString());
		levelManager.LoadLevel("Win Screen");
	}
}
