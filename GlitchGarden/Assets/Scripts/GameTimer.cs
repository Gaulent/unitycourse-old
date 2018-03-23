using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float timeRemaining = 60f;
	private float timeStart;
	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private GameObject winLabel;
	private bool gameWon;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timeStart = Time.time;
		audioSource = GetComponent<AudioSource>();
		gameWon = false;
		winLabel = GameObject.Find("You Win");
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value =  (Time.time-timeStart)/timeRemaining;
		if ((Time.time-timeStart)/timeRemaining >= 1 && ! gameWon) {
			gameWon = true;
			winLabel.SetActive(true);
			audioSource.Play();
			Invoke ("LoadNextLevel", audioSource.clip.length); //Clever
		}
	}
	
	void LoadNextLevel() {
		levelManager.LoadLevel("03a Win");
	}
}
