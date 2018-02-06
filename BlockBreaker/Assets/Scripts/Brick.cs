using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}
	
	void OnCollisionEnter2D (Collision2D c2d) {
		timesHit++;
		if(timesHit>=maxHits) Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
