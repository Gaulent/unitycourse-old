using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Lo pone en el editor aunque sea privado
	[SerializeField] public float speed = 10f;
	[SerializeField] public float climbSpeed = 10f;
	[SerializeField] public float jumpPotency = 5f;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator anim;
	private CapsuleCollider2D col;
	private BoxCollider2D colFeet;
	private float gravityScale;
	private bool isAlive = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		col = GetComponent<CapsuleCollider2D>();
		colFeet = GetComponent<BoxCollider2D>();
		print (colFeet.gameObject);
		gravityScale = rb.gravityScale;
		
	}
	
	void Update () {

		if(isAlive) {
			Run();
			Jump();
			Climb();
			Die ();
		}
	}

	void Jump () {

		if(CrossPlatformInputManager.GetButtonDown("Jump") && colFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			rb.velocity+=(new Vector2(0,jumpPotency));
		}
	}

	void Climb () {
		float verAxis = CrossPlatformInputManager.GetAxis("Vertical");
		if(Mathf.Abs(verAxis)>Mathf.Epsilon && col.IsTouchingLayers(LayerMask.GetMask("Ladder"))) {
			rb.velocity = new Vector2(rb.velocity.x, climbSpeed /** Time.deltaTime*/ * verAxis);
			anim.SetBool("climbing",true);
			rb.gravityScale = 0 ;
			
		}

			
		if(!col.IsTouchingLayers(LayerMask.GetMask("Ladder"))) {
			anim.SetBool("climbing",false);
			rb.gravityScale = gravityScale;
		}
		
	}
	
	void Die() {
		if(col.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard"))) {
			isAlive=false;
			anim.SetTrigger("dies");
			rb.velocity = new Vector2(10f,10f);
		}
		
		
	
	}
	
	void Run () {
		//Mathf.Epsilon es casi cero.
		float horAxis = CrossPlatformInputManager.GetAxis("Horizontal");
		if(horAxis < 0f)
			sr.flipX = true;
		else if(horAxis > 0f)
			sr.flipX = false;
		if(Mathf.Abs(horAxis) > Mathf.Epsilon)
			anim.SetBool("running",true);
		else
			anim.SetBool("running",false);
		rb.velocity = new Vector2(speed /** Time.deltaTime*/ * horAxis,rb.velocity.y);
		//transform.Translate(speed * Vector3.right * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal"));
	}
}
