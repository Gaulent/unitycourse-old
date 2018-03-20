using UnityEngine;
using System.Collections;

// Esta linea dice a Unity que este script requiere un componente llamado Attacker.
// En nuestro caso es otro script. Si no lo tiene lo metera por nosotros al incluir este.
[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D c2d) {
		if (c2d.GetComponent<Defender>()) {
			if (c2d.GetComponent<Stone>())
				animator.SetTrigger("jump trigger");
			else {
				animator.SetBool("isAttacking", true);
				attacker.Attack(c2d.gameObject);
			}
		}
		
	}
}
