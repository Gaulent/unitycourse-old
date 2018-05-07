using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	private static int[] bowls = new int[21];
	private static int bowl = 1;
	
	private static void ResetActionMaster () {
		bowl = 1;
		bowls = new int[21];
	}
	
	public static Action NextAction (List<int> rolls) {

		Action result = Action.Undefined;
		ResetActionMaster();
		
		foreach (int roll in rolls) {
			result = Bowl(roll);
		}
		
		return result;
	}

	private static Action Bowl (int pins) {
	
		if (pins < 0 || pins > 10) throw new UnityException("Invalid pins!");

		bowls [bowl - 1] = pins;
		
		if (bowl == 21) {
			return Action.EndGame;
		}

		if(bowl >= 19 && pins == 10) {
			bowl++;
			return Action.Reset;
		} else if(bowl == 20) {
			bowl++;
			if(bowls[19-1]==10 && bowls[20-1]==0) {
				return Action.Tidy;
			} else if (bowls[19-1] + bowls[20-1] == 10) {
				return Action.Reset;
			} else if (Bowl21Awarded()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}
		
		if (bowl % 2 != 0) {
			if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			}
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0) {
			bowl += 1;
			return Action.EndTurn;
		}
			
		throw new UnityException("Not sure what action to return!");
		//return Action.Undefined;
		
		
	}
	
	private static bool Bowl21Awarded() {
		return (bowls[19-1]+bowls[20-1] >= 10);
	}

	private static double ScoreFrames(List<int> n) {
		return 0;
	}
}