﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			// Wait for a mouse press for launch.
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D c2d) {
	
		Vector2 tweak = new Vector2(Random.Range (-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));
		
		if(hasStarted) {
			audio.Play();
			this.rigidbody2D.velocity += tweak;
		}
	}
}
