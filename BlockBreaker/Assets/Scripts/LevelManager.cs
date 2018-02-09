using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
	
	public void QuitRequest() {
		Debug.Log ("Requested to quit game");
		Application.Quit ();
	}
	
}
