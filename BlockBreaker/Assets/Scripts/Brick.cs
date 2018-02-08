using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		
	}
	
	// Tambien existe OnCollisionExit2D? que quiza es mas adecuado.
	void OnCollisionEnter2D (Collision2D c2d) {
		timesHit++;
		if(timesHit>=maxHits) Destroy(gameObject);
		//SimulateWin();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// TODO: Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	
	
	}
	
}
