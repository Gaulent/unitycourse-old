using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelManager lm;
	
	void Start() {
		lm = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D col) {
		lm.LoadLevel("03b Lose");
	}
}
