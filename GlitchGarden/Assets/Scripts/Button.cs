using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	private static GameObject selectedDefender;
	public GameObject defenderPrefab;
	private Button[] buttons;

	// Use this for initialization
	void Start () {
		buttons = FindObjectsOfType<Button>();
		GetComponent<SpriteRenderer>().color = Color.black;
	}
	
	void OnMouseDown() {
		foreach (Button button in buttons) {
			button.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
	
	public static GameObject GetSelectedDefender() {
		return selectedDefender;
	}
}
