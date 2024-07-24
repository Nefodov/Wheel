using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ValueObjects;

[CreateAssetMenu(menuName = "Scriptable Objects/GameController")]
public class GameControllerInterface : ScriptableObject
{
	public ActionVoidObject exitLose;
	public ActionVoidObject exitWin;

	[Header("Goal")]
	public ActionIntObject onGoalsChange;
	public ActionIntObject goalInited;
	public ActionIntObject goalCollected;

	[Header("Spike")]
	public ActionVoidObject onSpikeHit;

	public IntObject goalsTotal;
	public IntObject goalsLeft;

	public void OnSpikeHit()
	{
		SceneManager.UnloadSceneAsync(1);
		SceneManager.LoadScene(1, LoadSceneMode.Additive);
		Restart();
	}

	public void AddGoal(int value)
	{
		goalsLeft.Value += value;
		goalsTotal.Value += value;

		onGoalsChange.Invoke(goalsLeft.Value);
	}

	public void GoalDone(int value)
	{
		goalsLeft.Value -= value;
		onGoalsChange.Invoke(goalsLeft.Value);
	}
	
	public void Restart()
	{
		goalInited.RemoveListener(AddGoal);
		goalCollected.RemoveListener(GoalDone);
		onSpikeHit.RemoveListener(OnSpikeHit);

		goalsLeft.Value = 0;
		goalsTotal.Value = 0;
		goalInited.AddListener(AddGoal);
		goalCollected.AddListener(GoalDone);
		onSpikeHit.AddListener(OnSpikeHit);
	}

	public void ExitLose()
	{
		exitLose.Invoke();
		SceneManager.UnloadSceneAsync(1);
	}
	public void ExitWin()
	{
		exitWin.Invoke();
		SceneManager.UnloadSceneAsync(1);
	}
}
