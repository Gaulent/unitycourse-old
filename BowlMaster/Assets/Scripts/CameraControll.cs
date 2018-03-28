using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newCameraPosition;
		newCameraPosition = ball.transform.position + offset;
		if(newCameraPosition.z<=1829)
			transform.position = newCameraPosition;
	}
}
