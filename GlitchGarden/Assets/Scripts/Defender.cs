using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost = 100;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void AddStars(int n) {
		starDisplay.AddStars(n);
	}
}
