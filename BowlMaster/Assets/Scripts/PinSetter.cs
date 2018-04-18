using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public float distanceToRaise = 40f;
	public GameObject pinsPrefab;
	
	private Ball ball;
	private int lastSettledCount;
	private float lastChangeTime;
	private bool ballEnteredBox = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if(ballEnteredBox) {
			CheckStanding();
		}
	}

	public void RaisePins() {
		Pin[] pins = FindObjectsOfType<Pin>();
		
		foreach (Pin pin in pins) {
			if(pin.IsStanding()) {
				pin.RaisePin(distanceToRaise);
			}
		}
	}
	
	public void LowerPins() {
		Pin[] pins = FindObjectsOfType<Pin>();
		
		foreach (Pin pin in pins) {
			if(pin.IsStanding()) {
				pin.LowerPin();
			}
		}	
	}

	public void RenewPins() {
		GameObject pins = GameObject.Find("Bowling Pins");
		Destroy(pins);
		pins = Instantiate(pinsPrefab, new Vector3(0,0,1829), Quaternion.identity);
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

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;
		if (go.GetComponent<Ball>()) {
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;
		if (go.GetComponentInParent<Pin>()) {
			Destroy(go.transform.parent.gameObject);
		}
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
		int pinFall = lastSettledCount - CountStanding();
		lastSettledCount = CountStanding();
		
		ActionMaster.Action thisAction = ActionMaster.Bowl(pinFall);
		print (thisAction);
		if(thisAction==ActionMaster.Action.EndTurn) {
			anim.SetTrigger("resetTrigger");
		} else if(thisAction==ActionMaster.Action.Tidy) {
			anim.SetTrigger("tidyTrigger");
		}
		
		
		
		
		
		standingDisplay.color = Color.green;
		lastStandingCount = -1;
		ballEnteredBox = false;
		ball.Reset();
	}
}
