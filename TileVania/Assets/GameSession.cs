using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

	[SerializeField] int playerLives = 3;

	void Awake() {
		if(FindObjectsOfType<GameSession>().Length > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerDeath() {
		if (playerLives > 1) {
			playerLives--;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else {
			Destroy(gameObject);
			SceneManager.LoadScene(0);
		}
	}
}
