using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	[SerializeField] public AudioClip clip;
	private GameSession session;

	void Start() {
		session = FindObjectOfType<GameSession>();
	}

	// Interactables solo colisiona con el player
	void OnTriggerEnter2D(Collider2D cl) {
		session.CoinPicked();
		AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position);
		
		Destroy(gameObject);
		
	}
}
