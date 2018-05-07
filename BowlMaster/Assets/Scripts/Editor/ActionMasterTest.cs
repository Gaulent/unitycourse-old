using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionMasterTest {
	
	List<int> bowls_list;
	
	// Lo que se ponga aqui se lanza siempre al inicio de las pruebas.
	// Es como el start para las pruebas unitarias.
	
	[SetUp]
	public void Setup () {
		bowls_list = new List<int>();
	}
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}
	
	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		bowls_list.Add(10);
		Assert.AreEqual (ActionMaster.Action.EndTurn, ActionMaster.NextAction(bowls_list));
	}

	[Test]
	public void T02Bowl8ReturnsTidy () {
		bowls_list.Add(8);
		Assert.AreEqual (ActionMaster.Action.Tidy, ActionMaster.NextAction(bowls_list));
	}
	
	[Test]
	public void T03Bowl28SpareReturnsEndTurn () {
		bowls_list.Add(8);
		bowls_list.Add(2);
		Assert.AreEqual (ActionMaster.Action.EndTurn, ActionMaster.NextAction(bowls_list));
	}

	[Test]
	public void T04CheckResetAtStrikeInLastFrame () {
		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,10};
		Assert.AreEqual (ActionMaster.Action.Reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame () {
		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,9};
		Assert.AreEqual (ActionMaster.Action.Reset, ActionMaster.NextAction(rolls.ToList()));
	}	
	
	[Test]
	public void T06YouTubeRollsEndInEndGame () {
		int[] rolls = {8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2,9};
		Assert.AreEqual (ActionMaster.Action.EndGame, ActionMaster.NextAction(rolls.ToList()));
	}	
	
	[Test]
	public void T07GameEndsAtBowl20 () {
		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1};
		Assert.AreEqual (ActionMaster.Action.EndGame, ActionMaster.NextAction(rolls.ToList()));
	}	

	[Test]
	public void T08DarylBowl20Test () {
		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,5};
		Assert.AreEqual (ActionMaster.Action.Tidy, ActionMaster.NextAction(rolls.ToList()));
	}	

	[Test]
	public void T09BensBowl20Test () {
		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,0};
		Assert.AreEqual (ActionMaster.Action.Tidy, ActionMaster.NextAction(rolls.ToList()));
	}	
	
	[Test]
	public void T10NathanBowlIndexTest () {
		int[] rolls = {0,10,5,1};
		Assert.AreEqual (ActionMaster.Action.EndTurn, ActionMaster.NextAction(rolls.ToList()));
	}	

	[Test]
	public void T11Dondi10thFrameTurkey () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10};
		bowls_list = rolls.ToList();
		Assert.AreEqual (ActionMaster.Action.Reset, ActionMaster.NextAction(bowls_list));
		bowls_list.Add(10);
		Assert.AreEqual (ActionMaster.Action.Reset, ActionMaster.NextAction(bowls_list));
		bowls_list.Add(10);
		Assert.AreEqual (ActionMaster.Action.EndGame, ActionMaster.NextAction(bowls_list));
	}	

}