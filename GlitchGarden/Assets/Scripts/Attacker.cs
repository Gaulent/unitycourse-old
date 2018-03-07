using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] // OHMYGAWD
	public float currentSpeed;

	// Use this for initialization
	void Start () {
		// Añade en script un componente. En este caso el rigidbody, ya que es muy simple.
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D () {
		Debug.Log (name + " trigger enter");
	
	}
	
	void setSpeed (float Speed) {
		currentSpeed = Speed;
	}
	
	void StrikeCurrentTarget(float damage) {
		Debug.Log(name + " damage dealt.");
	}
}
