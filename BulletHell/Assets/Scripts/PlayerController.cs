using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 8f;
	public float padding = 1f;
	public GameObject laserPrefab;
	public float laserSpeed = 10f;
	public float firingRate = 1f;
	public float health = 250f;
	public enum Element {ICE, FIRE};
	public Element currentElement = Element.ICE;
	private float xmin,xmax,ymin,ymax;
	public Sprite fireSprite;
	public Sprite iceSprite;
	public AudioClip shoot_sfx;
	private Animator anim;
	private SpriteRenderer spriteR;
	private Gun[] guns;
	


	void Start () {
	
		// ViewportToWorldPoint devuelve puntos en el espacio en referencia a la camara
		// En este caso la camara Camera.main
		guns = GetComponentsInChildren<Gun>();
		anim = GetComponent<Animator>();
		spriteR = GetComponent<SpriteRenderer>();
		SetElementSprite(currentElement);

		float distance = transform.position.z - Camera.main.transform.position.z;
	
		//Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0.26f,0f,distance));
		//Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f-0.26f,1f,distance));
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f,1f,distance));

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		ymin = leftmost.y + padding;
		ymax = rightmost.y - padding;
		//lvlManager = FindObjectOfType<LevelManager>();
	}
	
	void Fire() {

		foreach(Gun gun in guns) {
			GameObject laser = Instantiate(laserPrefab, gun.transform.position, gun.transform.rotation) as GameObject;
			laser.GetComponent<Rigidbody2D>().velocity = gun.aim*laserSpeed;
			laser.GetComponent<SpriteRenderer>().color = GetColor();
		}
		AudioSource.PlayClipAtPoint(shoot_sfx, transform.position, 0.02f);
	}

	void SetElementSprite(Element element) {
		if(element == Element.ICE)
			spriteR.sprite = iceSprite;
		else if (element == Element.FIRE)
			spriteR.sprite = fireSprite;
		else
			Debug.LogWarning("Trying to assign invalid element.");
	}

	void Update () {
	
		// Time.deltaTime es el tiempo entre frames. Haciendolo independiente del framerate.
	
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			// Hay un bug que se produce al meter 0.0f ahi
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Z)) {
			CancelInvoke("Fire");
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			// Hay un bug que se produce al meter 0.0f ahi
			anim.SetTrigger("MorphTrigger");
		}
		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
		transform.position = new Vector3(newX, newY, transform.position.z);
		
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		Laser projectile = col.gameObject.GetComponent<Laser>();
		if(projectile) {
			health -= projectile.GetDamage();
			//Debug.Log ("Player hit.");
			projectile.Hit();
			if(health<=0) {
				Destroy (gameObject);
				//lvlManager.LoadNextLevel();
				LevelManager man = GameObject.Find("Level Manager").GetComponent<LevelManager>();
				man.LoadNextLevel();
			}
		}
	}
	
	public void MorphElement() {
		if (currentElement==Element.FIRE) currentElement=Element.ICE;
		else if (currentElement==Element.ICE) currentElement=Element.FIRE;
		SetElementSprite(currentElement);
	}

	Color GetColor() {
		if (currentElement==Element.FIRE) return Color.red;
		else if (currentElement==Element.ICE) return Color.cyan;
		return Color.black;
	}
}
