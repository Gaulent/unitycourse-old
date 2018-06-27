using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

	[SerializeField] int playerLives = 3;
	[SerializeField] int coins = 0;
	[SerializeField] Text livesText;
	[SerializeField] Text scoreText;
	
	

	void Awake() {
		if(FindObjectsOfType<GameSession>().Length > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void LinkToHUD () {
		if(!livesText)
			livesText = GameObject.Find("Lives").GetComponent<Text>();
		if(!scoreText)
			scoreText = GameObject.Find("Score").GetComponent<Text>();
	}
	
	void Start() {
		LinkToHUD();
	}
	
	// Update is called once per frame
	void Update () {
		livesText.text = playerLives.ToString();
		scoreText.text = coins.ToString();
		
	}

	public void PlayerDeath() {
		if (playerLives > 1) {
			playerLives--;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else {
			coins = 0;
			Destroy(gameObject);
			SceneManager.LoadScene(0);
		}
	}
	
	public void CoinPicked() {
		coins+=100;
	}
}
