using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ValueObjects;

[CreateAssetMenu(menuName = "Scriptable Objects/GameController")]
public class GameControllerInterface : ScriptableObject
{
	[Header("Goal")]
	public ActionIntObject onGoalsChange;
	public ActionIntObject goalInited;
	public ActionIntObject goalCollected;

	[Header("Spike")]
	public ActionVoidObject onSpikeHit;

	private int goals;

	public void OnSpikeHit()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		Restart();
	}

	public void AddGoal(int value)
	{
		goals+= value;
		onGoalsChange.Invoke(goals);
	}

	public void GoalDone(int value)
	{
		goals-= value;
		onGoalsChange.Invoke(goals);
	}
	
	public void Restart()
	{
		goalInited.RemoveListener(AddGoal);
		goalCollected.RemoveListener(GoalDone);
		onSpikeHit.RemoveListener(OnSpikeHit);

		goals = 0;
		goalInited.AddListener(AddGoal);
		goalCollected.AddListener(GoalDone);
		onSpikeHit.AddListener(OnSpikeHit);
	}
}
