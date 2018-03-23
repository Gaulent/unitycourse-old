using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	private static GameObject selectedDefender;
	public GameObject defenderPrefab;
	private Button[] buttons;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttons = FindObjectsOfType<Button>();
		GetComponent<SpriteRenderer>().color = Color.black;
		GetComponentInChildren<Text>().text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
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
