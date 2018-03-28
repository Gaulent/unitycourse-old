using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchSpeed;
	
	private Rigidbody rigidBody;
	private AudioSource ballSound;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		ballSound = GetComponent<AudioSource>();
		LaunchBall();
	}

	public void LaunchBall ()
	{
		rigidBody.velocity = launchSpeed;
		ballSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
