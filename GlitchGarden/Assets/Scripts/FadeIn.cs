using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	
	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		fadePanel.color = currentColor;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeInTime){
			currentColor.a = 1-(Time.timeSinceLevelLoad/fadeInTime);
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive(false);
		}
		
/*		alpha += 1;
		Image i = GetComponent<Image>();
		Color c = i.color;
		c.a = alpha;
		i.color = c;}*/
	}
}
