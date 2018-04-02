using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		//Application.LoadLevel(name);
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel() {
		//Application.LoadLevel(Application.loadedLevel + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void QuitRequest() {
		//Debug.Log ("Requested to quit game");
		Application.Quit ();
	}
	
}
