using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public AudioClip callSound;
	
	private AudioSource	audioSource;
	private bool called = false;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
	}
	
	public void Call () {
		if(!called /*&& Input.GetButtonDown("CallHeli")*/) {
			called = true;
			audioSource.clip = callSound;
			audioSource.Play();
			Debug.Log("Helicopter called");
			rigidBody.velocity = new Vector3 (0,0,50f);
		}
	}
}
