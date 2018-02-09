using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;
	
	private bool isBreakable;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable)
			breakableCount++;

		
		
				
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		Debug.Log(breakableCount);
	}
	
	// Tambien existe OnCollisionExit2D? que quiza es mas adecuado.
	void OnCollisionEnter2D (Collision2D c2d) {
		// deja el sonido en un punto del espacio para que siga
		// sonando incluso cuando el ladrillo es destruido.
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.1f);
		if(isBreakable)
			HandleHits();
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit>=maxHits) {	
			breakableCount--;
			Debug.Log(breakableCount);
			PuffSmoke();
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else LoadSprites();
	}
	
	void PuffSmoke() {
		//smoke.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
		GameObject smokePuff = Instantiate(smoke,gameObject.transform.position,Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	// Update is called once per frame
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		else
			Debug.LogError("Sprite " + spriteIndex + " is missing.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
