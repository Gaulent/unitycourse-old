using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarDisplay starDisplay;
	
	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		parent = GameObject.Find("Defenders");
		if(!parent) {
			parent = new GameObject("Defenders");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		if (Button.GetSelectedDefender()) {
			Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
			GameObject defender = Button.GetSelectedDefender();
			if (starDisplay.UseStars(defender.GetComponent<Defender>().starCost) == StarDisplay.Status.SUCCESS) {
				GameObject newDefender = Instantiate(defender, spawnPosition, Quaternion.identity) as GameObject;
				newDefender.transform.parent = parent.transform;
			}
		}
	}
}
