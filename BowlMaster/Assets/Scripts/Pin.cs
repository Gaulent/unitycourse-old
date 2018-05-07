using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	[Range(0f,1f)]
	public float standingThreshold = 0.25f;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
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
	
	public void RaisePin(float distanceToRaise) {
		transform.Translate(Vector3.up*distanceToRaise);
		rb.useGravity = false;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.Euler(0f,0f,0f);
	}
	
	public void LowerPin() {
		rb.useGravity = true;
	}
}
