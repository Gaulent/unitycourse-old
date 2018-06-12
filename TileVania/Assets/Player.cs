﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Lo pone en el editor aunque sea privado
	[SerializeField] public float speed = 10f;
	[SerializeField] public float jumpPotency = 5f;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {

		Run();
		Jump();
	}

	void Jump () {

		if(CrossPlatformInputManager.GetButtonDown("Jump")) {
			Debug.Log("Log");
			rb.velocity+=(new Vector2(0,jumpPotency));
		}
	}


	void Run () {
		//Mathf.Epsilon es casi cero.
		float horAxis = CrossPlatformInputManager.GetAxis("Horizontal");
		if(horAxis < 0f)
			sr.flipX = true;
		else if(horAxis > 0f)
			sr.flipX = false;
		if(Mathf.Abs(horAxis) > Mathf.Epsilon)
			anim.SetBool("running",true);
		else
			anim.SetBool("running",false);
		rb.velocity = new Vector2(speed /** Time.deltaTime*/ * horAxis,rb.velocity.y);
		//transform.Translate(speed * Vector3.right * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal"));
	}
}
