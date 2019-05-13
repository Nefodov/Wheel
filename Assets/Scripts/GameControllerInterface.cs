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
		goalsLeft.value += value;
		goalsTotal.value += value;

		onGoalsChange.Invoke(goalsLeft.value);
	}

	public void GoalDone(int value)
	{
		goalsLeft.value -= value;
		onGoalsChange.Invoke(goalsLeft.value);
	}
	
	public void Restart()
	{
		goalInited.RemoveListener(AddGoal);
		goalCollected.RemoveListener(GoalDone);
		onSpikeHit.RemoveListener(OnSpikeHit);

		goalsLeft.value = 0;
		goalsTotal.value = 0;
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
