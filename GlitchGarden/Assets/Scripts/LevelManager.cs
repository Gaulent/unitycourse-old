using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter=0;

	void Start () {
		if(autoLoadNextLevelAfter>0)
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
	}

	public void LoadLevel(string name) {
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		Debug.Log ("Loading Next Level.");
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest() {
		Debug.Log ("Requested to quit game");
		Application.Quit ();
	}
	
}
