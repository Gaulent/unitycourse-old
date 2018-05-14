using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;
	public AudioClip goodLandingArea;
	
	private AudioSource innerVoice;
	

	// Use this for initialization
	void Start () {
		innerVoice = GetComponent<AudioSource>();
		
		innerVoice.clip = whatHappened;
		innerVoice.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnFindClearArea() {
		print (name + "OnFindClearArea");
		innerVoice.clip = goodLandingArea;
		innerVoice.Play();
		
		Invoke ("CallHeli", goodLandingArea.length + 1f);
	}
	
	void CallHeli() {
		SendMessageUpwards("OnMakeInitialHeliCall");
	}
}
