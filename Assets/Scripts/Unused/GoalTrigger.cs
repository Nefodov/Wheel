using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
	public GameControllerInterface controllerInterface;

	private void Start()
	{
		controllerInterface.AddGoal();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.SetActive(false);
		controllerInterface.OnGoalHit();
	}
}
