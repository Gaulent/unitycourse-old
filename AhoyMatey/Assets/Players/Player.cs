using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine;

// NetworkBehavious añade cosas chulas de red a MonoBehaviour
public class Player : NetworkBehaviour {

	private Vector3 inputValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer) {
			return;
		}
		
		inputValue.x = CrossPlatformInputManager.GetAxis("Horizontal");
		inputValue.y = 0f;
		inputValue.z = CrossPlatformInputManager.GetAxis("Vertical");
		
		transform.Translate(inputValue);
	}

	override public void OnStartLocalPlayer() {
		GetComponentInChildren<Camera>().enabled = true;
	}
}
