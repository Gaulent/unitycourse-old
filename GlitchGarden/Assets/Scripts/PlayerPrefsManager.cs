using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	// const son tambien static (al menos en c-sharp)
	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume) {
		if(volume >= 0f && volume <= 1f)
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		else
			Debug.LogError("Master volume out of range");
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if(level <= Application.levelCount - 1)
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		else
			Debug.LogError("Trying to unlock level not in build order");
	}
	
	public static bool IsLevelUnlocked (int level) {
		if(level <= Application.levelCount - 1)
			return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString())==1);
		Debug.LogError("Trying to check level not build in order");
		return false;
	}
	
	public static void SetDifficulty (int difficulty) {
		if(difficulty >= 1 && difficulty <= 3)
			PlayerPrefs.SetInt(DIFF_KEY, difficulty);
		else
			Debug.LogError("Master volume out of range");
	}
	
	public static int GetDifficulty () {
		return PlayerPrefs.GetInt(DIFF_KEY);
	}
	
	
}
