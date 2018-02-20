using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource music;
	
	// Awake() will be called before Start() as soon as the objects are initialised
	// more info on: https://docs.unity3d.com/Manual/ExecutionOrder.html
	// Game Patterns: http://gameprogrammingpatterns.com/
	
	void Awake() {
			DontDestroyOnLoad(gameObject);	
			/*music = GetComponent<AudioSource>();
			music.clip = levelMusicChangeArray[0];
			music.loop = true;
			music.Play();*/
	}

	void Start() {
		music = GetComponent<AudioSource>();
		music.volume = PlayerPrefsManager.GetMasterVolume();
	}
			
	
	// Nuevo "metodo automatico" que se llama con el ID del audio que ha sido llamado.
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("MusicPlayer: loaded level " + level);
		
		if(thisLevelMusic && music) {
			music.clip = levelMusicChangeArray[level];
			music.loop = true;
			music.Play();
		}
	}
	
	public void ChangeVolume(float volume) {
		music.volume = volume;
	}
}
