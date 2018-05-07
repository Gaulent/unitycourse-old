using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

	private PinSetter pinSetter;
	List<int> bowlList;
	private Ball ball;

	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		bowlList = new List<int>();
		ball = GameObject.FindObjectOfType<Ball>();
	}

	public void Bowl(int pinFall) {
		
		bowlList.Add (pinFall);

		
		ActionMaster.Action thisAction = ActionMaster.NextAction(bowlList);
		print (thisAction);
		pinSetter.PerformAction(thisAction);
		ball.Reset();
		
		

	}
}
