using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	public Text guessText;
	int max = 1000;
	int min = 1;
	int guess;
	
	// Use this for initialization
	void Start () {
		NextGuess();
		max++;
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
		//guess = (max+min)/2;
		guess = Random.Range (min,max);
		Debug.Log ("Guess: " + guess);
		guessText.text = guess.ToString();
	}
}
