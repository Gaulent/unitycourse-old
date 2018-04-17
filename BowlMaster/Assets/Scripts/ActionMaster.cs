using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	private static int[] bowls = new int[21];
	private static int bowl = 1;
	
	public static void ResetActionMaster () {
		bowl = 1;
		bowls = new int[21];
	}
	
	public static Action NextAction (List<int> rolls) {
		Action nextAction = Action.Undefined;
		
		for (int i = 0; i < rolls.Count; i++) { // Step through rolls
			
			if (i == 20) {
				nextAction = Action.EndGame;
			} else if ( i >= 18 && rolls[i] == 10 ){ // Handle last-frame special cases
				nextAction = Action.Reset;
			} else if ( i == 19 ) {
				if (rolls[18]==10 && rolls[19]==0) {
					nextAction = Action.Tidy;
				} else if (rolls[18] + rolls[19] == 10) {
					nextAction = Action.Reset;
				} else if (rolls [18] + rolls[19] >= 10) {  // Roll 21 awarded
					nextAction = Action.Tidy;
				} else {
					nextAction = Action.EndGame;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (rolls[i] == 10) {
					rolls.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = Action.EndTurn;
				} else {
					nextAction = Action.Tidy;
				}
			} else { // Second bowl of frame
				nextAction = Action.EndTurn;
			}
		}
		
		return nextAction;
	}

	public static Action Bowl (int pins) {
	
		if (pins < 0 || pins > 10) throw new UnityException("Invalid pins!");

		bowls [bowl - 1] = pins;
		
		if (bowl == 21) {
			return Action.EndGame;
		}
		if (bowl == 20 && bowls[19-1] == 10) {
			return Action.Tidy;
		}
		if (bowl >= 19 && Bowl21Awarded()) {
			bowl += 1;
			return Action.Reset;
		} else if (bowl == 20 && !Bowl21Awarded()) {
			return Action.EndGame;
		}
		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;
		}
		
		if (bowl % 2 != 0) {
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0) {
			bowl += 1;
			return Action.EndTurn;
		}
			
		throw new UnityException("Not sure what action to return!");
		//return Action.Undefined;
		
		
	}
	
	public static bool Bowl21Awarded() {
		return (bowls[19-1]+bowls[20-1] >= 10);
	}

	public static double ScoreFrames(List<int> n) {
		return 0;
	}
}