using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

	[SerializeField] float levelLoadDelay = 2f;
	bool levelEnded = false;


	void OnTriggerEnter2D() {
		if(!levelEnded) levelEnded = true;
		else return;

		Time.timeScale = 0.2f;
		StartCoroutine(LoadNextLevel());
	}

	/* OLD FASHION. Mirar que es eso de los IEnum y las corrutinas.
	void NextLevel() {
		Time.timeScale = 1f;
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene+1);
	}*/

	IEnumerator LoadNextLevel() {
		yield return new WaitForSecondsRealtime(levelLoadDelay);

		Time.timeScale = 1f;
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene+1);
	}
}
