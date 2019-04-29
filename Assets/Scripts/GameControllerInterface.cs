using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scriptable Objects/GameController")]
public class GameControllerInterface : ScriptableObject
{
	public Action<int> onGoalsChange;

	private int goals;

	public void OnGoalHit()
	{
		GoalDone();
	}

	public void OnSpikeHit()
	{
		Restart();
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

	public void AddGoal()
	{
		goals++;
		onGoalsChange?.Invoke(goals);
	}

	public void GoalDone()
	{
		goals--;
		onGoalsChange?.Invoke(goals);
	}
	
	public void Restart()
	{
		goals = 0;
	}
}
