using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;
	
	// Awake() will be called before Start() as soon as the objects are initialised
	// more info on: https://docs.unity3d.com/Manual/ExecutionOrder.html
	// Game Patterns: http://gameprogrammingpatterns.com/
	
	void Start() {
		if (instance != null && instance != this) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);	
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}
	
	
	// Nuevo "metodo automatico" que se llama con el ID del audio que ha sido llamado.
	void OnLevelWasLoaded(int level) {
		Debug.Log ("MusicPlayer: loaded level " + level);
		if(music) {
			music.Stop();
	
			if(level==0)
				music.clip = startClip;
			else if(level==1)
				music.clip = gameClip;
			else if(level==2)
				music.clip = endClip;
			music.loop = true;
			music.Play();
		}
	}
}
