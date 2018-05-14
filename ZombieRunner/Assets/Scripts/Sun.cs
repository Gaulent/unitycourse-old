using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	[Tooltip ("Number of minutes per second that pass, try 60")]
	public float timeScale = 60f; // 1 segundo real = 1 minuto en juego.
	
	private Vector3 currentPosition;

	// Use this for initialization
	void Start () {
		currentPosition = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition.x += (Time.deltaTime * timeScale * 360f) / (24f * 60f * 60f);
		currentPosition.x = currentPosition.x % 360f;
		transform.rotation = Quaternion.Euler(currentPosition);
	}
}
