using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	
	
	public int lastStandingCount = -1;
	public Text standingDisplay;
	
	
	private int lastSettledCount = 10;
	private float lastChangeTime;
	public bool ballOutOfPlay = false;
	

	private GameManager gameManager;

	
	// Update is called once per frame
	void OnTriggerExit (Collider col) {
		GameObject go = col.gameObject;
		if(go.GetComponent<Ball>()) {
			standingDisplay.color = Color.red;
			ballOutOfPlay = true;
		}
	}

	
	
	
	
	
	
	
	
	// Use this for initialization
	void Start () {
		
		
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if(ballOutOfPlay) {
			CheckStanding();
		}
	}
	
	int CountStanding() {
		Pin[] pins = FindObjectsOfType<Pin>();
		int cont = 0;
		
		foreach (Pin pin in pins) {
			if (pin.IsStanding())
				cont++;
		}
		
		return cont;
	}
	
	void CheckStanding () {
		// Update the lastStandingCount
		// Call PinHaveSettled() when they have
		if(lastStandingCount!= CountStanding()) {
			lastStandingCount = CountStanding();
			lastChangeTime = Time.time;
		}
		if (lastChangeTime + 3 <= Time.time) {
			PinsHaveSettled();
		}
	}
	
	void PinsHaveSettled() {
		
		ballOutOfPlay = false;

		
		if(CountStanding()==0)
			lastSettledCount = 10;
		else
			lastSettledCount = CountStanding();
		
		int pinFall = lastSettledCount - CountStanding();
		
		gameManager.Bowl(pinFall);
		
		standingDisplay.color = Color.green;
		lastStandingCount = -1;
		
	}
}
