using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	// Manual de Colliders: https://docs.unity3d.com/Manual/CollidersOverview.html
	// Detalla los tipos de collider (static, rigid body, kinematic) y si
	// la interaccion con estos lanza un mensaje collider o un trigger.
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}	
	
	void OnTriggerEnter2D (Collider2D c2d) {
		Debug.Log ("OnTriggerEnter2D --> " + c2d.ToString());
		levelManager.LoadLevel("Lose Screen");
	}
	/*
	void OnCollisionEnter2D (Collision2D c2d) {
		Debug.Log ("OnCollisionEnter2D --> " + c2d.ToString());
		levelManager.LoadLevel("Win Screen");
	}*/
}
