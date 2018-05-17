using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrame = new MyKeyFrame[bufferFrames];

	private Rigidbody rigidBody;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.recording)
			Record();
		else
			PlayBack();
	}

	void PlayBack() {
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		transform.position = keyFrame [frame].pos;
		transform.rotation = keyFrame [frame].rot;
	}

	void Record () {
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		keyFrame [frame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
	}
}

/// <summary>
/// A structure for storing time, rotation and position.
/// </summary>
public class MyKeyFrame {

	public float time;
	public Vector3 pos;
	public Quaternion rot;
	
	public MyKeyFrame(float newTime, Vector3 newPos, Quaternion newRot) {
		time = newTime;
		pos = newPos;
		rot = newRot;
	}
	
	public override string ToString() {
		return time.ToString() + pos.ToString() + rot.ToString();
	}
}