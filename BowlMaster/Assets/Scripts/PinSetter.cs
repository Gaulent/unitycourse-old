using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public float distanceToRaise = 40f;
	public GameObject pinsPrefab;
	private Animator anim;
	
	
	public void Start() {
		anim = GetComponent<Animator>();
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
	
	public void PerformAction(ActionMaster.Action thisAction) {
	
		if(thisAction==ActionMaster.Action.EndTurn)
			anim.SetTrigger("resetTrigger");
		else if(thisAction==ActionMaster.Action.Tidy)
			anim.SetTrigger("tidyTrigger");
	}
	
	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;
		if (go.GetComponentInParent<Pin>()) {
			Destroy(go.transform.parent.gameObject);
		}
	}
	
}
