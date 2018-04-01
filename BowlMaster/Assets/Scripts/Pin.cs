using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	[Range(0f,1f)]
	public float standingThreshold = 0.25f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//print(IsStanding());
	}

	public bool IsStanding() {
		// transform.rotation.eulerAngles; convierte la rotacion de quaternion a angulos
		Vector2 position = new Vector2 (transform.rotation.x, transform.rotation.z);
		return (position.magnitude<=standingThreshold);
	}
}
