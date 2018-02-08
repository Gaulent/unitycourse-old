using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest() {
		Debug.Log ("Requested to quit game");
		Application.Quit ();
	}
	
}
