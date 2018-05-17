using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;
	private float initialFixedDelta;

	// Use this for initialization
	void Start () {
		initialFixedDelta = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		recording = !CrossPlatformInputManager.GetButton("Fire1");
		
		if(Input.GetKeyDown(KeyCode.P)) {
			PauseGame();
		}
		if(Input.GetKeyDown(KeyCode.R)) {
			ResumeGame();
		}
	}
	
	void PauseGame() {
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	void ResumeGame() {
		Time.timeScale = 1f;
		Time.fixedDeltaTime = initialFixedDelta;
	}
}
