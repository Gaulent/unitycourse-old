using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAreaDetector : MonoBehaviour {

	public float timeSinceLastTrigger = 0f;
	private bool found = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;
		if (timeSinceLastTrigger>=1f && !found && Time.realtimeSinceStartup > 10f) {
			found = true;
			SendMessageUpwards("OnFindClearArea");
		}
	}
	
	void OnTriggerStay(Collider collider) {
		if(collider.tag != "Player") {
			timeSinceLastTrigger = 0f;
			}
	}

}
