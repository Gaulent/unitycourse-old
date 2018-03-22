using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	private int starCurrency = 100;
	public enum Status {SUCCESS, FAILURE};
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.text = starCurrency.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars(int n) {
		starCurrency+=n;
		text.text = starCurrency.ToString();
	}

	public Status UseStars(int n) {
		if(starCurrency >= n) {
			starCurrency-=n;
			text.text = starCurrency.ToString();
			return Status.SUCCESS;
		}
		else {
			Debug.Log("Insufficient stars.");
			return Status.FAILURE;
		}
	}
}
