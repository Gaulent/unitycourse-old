using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {

	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int>();

		int[] rollsArray = rolls.ToArray();

		int i = 0;
		for (i = 0; i< rollsArray.Length-2; i++) {
			if(rollsArray[i] == 10)
				frameList.Add(rollsArray[i]+rollsArray[i+1]+rollsArray[i+2]);
			else if(rollsArray[i] + rollsArray[i+1] == 10) {
				frameList.Add(rollsArray[i]+rollsArray[i+1]+rollsArray[i+2]);
				i++;
			}
			else {
				frameList.Add(rollsArray[i]+rollsArray[i+1]);
				i++;
			}
		}

		if(i+2 == rollsArray.Length && rollsArray[i]+rollsArray[i+1] < 10 && frameList.Count <10)
			frameList.Add(rollsArray[i]+rollsArray[i+1]);
		
		return frameList;
	}
	
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> frameList = new List<int>();
		List<int> scoreFrames = ScoreFrames(rolls);

		int cumulative = 0;
		foreach (int frame in scoreFrames) {
			cumulative+=frame;
			frameList.Add(cumulative);
		}
		
		return frameList;
	}
	
}