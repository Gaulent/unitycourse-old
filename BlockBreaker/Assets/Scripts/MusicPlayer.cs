using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	// Awake() will be called before Start() as soon as the objects are initialised
	void Awake () {
		if (instance != null) {
			Destroy(gameObject);
			Debug.Log ("Duplicate music player self-destructing!");
		}
	}
	
	// Use this for initialization
	void Start () {
		instance = this;
		GameObject.DontDestroyOnLoad(gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}	
}
