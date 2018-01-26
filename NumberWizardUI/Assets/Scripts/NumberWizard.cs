using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	public Text guessText;
	public int maxGuesses = 5;
	int max = 1000;
	int min = 1;
	int guess;
	
	// Use this for initialization
	void Start () {
		NextGuess();
	}
	
	public void GuessHigher() {
		min = guess;
		NextGuess();	
	}

	public void GuessLower() {
		max = guess;
		NextGuess();	
	}
	
	void NextGuess(){
		if(maxGuesses <= 0)
			Application.LoadLevel("Lose Screen");
		//Debug.Log(maxGuesses);
		maxGuesses--;
		guess = Random.Range (min,max+1);
		guessText.text = guess.ToString();
	}
}
