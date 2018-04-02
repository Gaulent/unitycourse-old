using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	public AudioClip musicClip;
	private AudioSource music;

	void Awake() {
		// - Singleton
		if (instance != null && instance != this) {
			Destroy(gameObject);
		}
	}

	void Start() {
		music = GetComponent<AudioSource>();
		music.clip = musicClip;
		music.loop = true;
		music.Play();
	}
}
