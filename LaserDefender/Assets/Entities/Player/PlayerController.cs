using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 8f;
	public float padding = 1f;
	public GameObject laserPrefab;
	public float laserSpeed = 10f;
	public float firingRate = 1f;
	public float health = 250f;
	private float xmin,xmax;
	public AudioClip shoot_sfx;
	//private LevelManager lvlManager;
	


	void Start () {
	
		// ViewportToWorldPoint devuelve puntos en el espacio en referencia a la camara
		// En este caso la camara Camera.main
	
		float distance = transform.position.z - Camera.main.transform.position.z;
	
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		
		//lvlManager = FindObjectOfType<LevelManager>();
	}
	
	void Fire() {
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0,laserSpeed,0);
		AudioSource.PlayClipAtPoint(shoot_sfx, transform.position, 0.02f);
	}
	
	void Update () {
	
		// Time.deltaTime es el tiempo entre frames. Haciendolo independiente del framerate.
	
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			// Hay un bug que se produce al meter 0.0f ahi
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		Laser projectile = col.gameObject.GetComponent<Laser>();
		if(projectile) {
			health -= projectile.GetDamage();
			Debug.Log ("Player hit.");
			projectile.Hit();
			if(health<=0) {
				Destroy (gameObject);
				//lvlManager.LoadNextLevel();
				LevelManager man = GameObject.Find("Level Manager").GetComponent<LevelManager>();
				man.LoadNextLevel();
			}
		}
	}
}
