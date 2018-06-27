using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

	private int scene;

	void Awake() {
		scene = SceneManager.GetActiveScene().buildIndex;
		if(FindObjectsOfType<ScenePersist>().Length > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(scene!=SceneManager.GetActiveScene().buildIndex)
			Destroy(gameObject);
	}
}
