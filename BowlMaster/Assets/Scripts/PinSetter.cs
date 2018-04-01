using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
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
			print("Ball Entered");
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject.transform.parent.gameObject;
		print("Something");
		if (go.GetComponentInParent<Pin>()) {
			Destroy(go);
		}
	}
}
