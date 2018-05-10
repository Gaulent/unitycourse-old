using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public AudioClip callSound;
	
	private AudioSource	audioSource;
	private bool called = false;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!called && Input.GetButtonDown("CallHeli")) {
			called = true;
			audioSource.clip = callSound;
			audioSource.Play();
			Debug.Log("Helicopter called");
		}
	}
}
