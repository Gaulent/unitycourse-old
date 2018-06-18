using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] public float speed = 1f;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private bool goingRight = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(goingRight)
			rb.velocity = new Vector2(speed,0f);
		else
			rb.velocity = new Vector2(-speed,0f);
	}
	
	void OnTriggerExit2D(Collider2D col) {
		//Debug.Log(col.collider.gameObject);
		goingRight=!goingRight;
		sr.flipX = !goingRight;
		
	}
}
