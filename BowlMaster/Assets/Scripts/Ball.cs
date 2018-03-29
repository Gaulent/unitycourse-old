using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchSpeed;
	
	private Rigidbody rigidBody;
	private AudioSource ballSound;
	private bool gameStarted = false;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		ballSound = GetComponent<AudioSource>();
		rigidBody.useGravity = false;
		//Launch(launchSpeed);
	}

	public void Launch (Vector3 velocity) {
		rigidBody.velocity = velocity;
		rigidBody.useGravity = true;
		ballSound.Play ();
		gameStarted = true;
	}

	public void MoveStart(float xNudge) {
		if(!gameStarted) {
			Vector3 newposition = transform.position + Vector3.right * xNudge;
			newposition.x = Mathf.Clamp(newposition.x, -50, 50);
			transform.position = newposition;
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
