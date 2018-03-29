using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private float startTime;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void DragStart() {
		startTime = Time.time;
		startPosition = Input.mousePosition;
	}

	public void DragEnd() {
		Vector3 velocity = (Input.mousePosition - startPosition) / (Time.time - startTime);
		velocity = new Vector3(velocity.x, 0, velocity.y);
		ball.Launch(velocity);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
