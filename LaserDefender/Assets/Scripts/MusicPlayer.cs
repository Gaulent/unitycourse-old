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
		} else {
			instance = this;
			this.audio.Play();
			GameObject.DontDestroyOnLoad(gameObject);	
		}
	}
}
