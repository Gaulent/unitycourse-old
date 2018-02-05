using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	// Awake() will be called before Start() as soon as the objects are initialised
	// more info on: https://docs.unity3d.com/Manual/ExecutionOrder.html
	// Game Patterns: http://gameprogrammingpatterns.com/
	
	void Awake () {
		if (instance != null) {
			Destroy(gameObject);
			Debug.Log ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);	
		}
	}
		
	// Update is called once per frame
	void Update () {
		
	}	
}
