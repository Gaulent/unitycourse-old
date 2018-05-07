using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchSpeed;
	
	private Vector3 initialPosition;
	private Rigidbody rigidBody;
	private AudioSource ballSound;
	private bool gameStarted = false;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		ballSound = GetComponent<AudioSource>();
		rigidBody.useGravity = false;
		Launch(new Vector3(0,2, 1600));
		initialPosition = transform.position;
	}

	public void Launch (Vector3 velocity) {
		if(!gameStarted) {
			rigidBody.velocity = velocity;
			rigidBody.useGravity = true;
			ballSound.Play ();
			gameStarted = true;
		}
	}

	public void MoveStart(float xNudge) {
		if(!gameStarted) {
			Vector3 newposition = transform.position + Vector3.right * xNudge;
			newposition.x = Mathf.Clamp(newposition.x, -50, 50);
			transform.position = newposition;
		}
	}

	public void Reset() {
		transform.position = initialPosition;
		transform.rotation = Quaternion.identity;
		gameStarted = false;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
