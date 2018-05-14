using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;
	private AudioSource radioSystem;
	
	
	// Use this for initialization
	void Start () {
		radioSystem = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMakeInitialHeliCall () {
		radioSystem.clip = initialHeliCall;
		radioSystem.Play();
		Invoke("OnMakeInitialCallReply",initialHeliCall.length + 1f);
	}
	
	void OnMakeInitialCallReply () {
		radioSystem.clip = initialCallReply;
		radioSystem.Play();
		BroadcastMessage("OnDispatchHelicopter");
	}
}
