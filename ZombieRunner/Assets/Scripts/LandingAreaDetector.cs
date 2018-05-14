using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAreaDetector : MonoBehaviour {

	private AudioSource audioSource;
	private float timeSinceLastTrigger = 0f;
	private bool found = false;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;
		if (timeSinceLastTrigger>=1f && !found) {
			found = true;
			audioSource.Play();
			SendMessageUpwards("OnFindClearArea");
		}
	}
	
	void OnTriggerStay() {
		timeSinceLastTrigger = 0f;
		found = false;
		
	}
}
