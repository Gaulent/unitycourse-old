using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	//[Range (-1f, 1.5f)] // OHMYGAWD
	//public float currentSpeed;
	private float currentSpeed;
	private GameObject target;
	private Animator animator;
	

	// Use this for initialization
	void Start () {
		// Añade en script un componente. En este caso el rigidbody, ya que es muy simple.
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!target) animator.SetBool("isAttacking", false);
	}
	
	void setSpeed (float Speed) {
		currentSpeed = Speed;
	}
	
	void StrikeCurrentTarget(float damage) {
		Debug.Log(name + " damage dealt.");
		if(target) {
			Health targetHealth = target.GetComponent<Health>();
			if(targetHealth)
				targetHealth.DealDamage(50);
		}
	}
	
	public void Attack(GameObject newTarget) {
		target = newTarget;
	}
}
