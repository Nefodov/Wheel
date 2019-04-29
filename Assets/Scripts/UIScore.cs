using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
	static readonly string format = "GoalsLeft: {0}";

	public TextMeshProUGUI text;
	public GameControllerInterface controllerInterface; 

	private void OnEnable()
	{
		controllerInterface.onGoalsChange += SetScore;
	}

	private void OnDisable()
	{
		controllerInterface.onGoalsChange -= SetScore;
	}

	public void SetScore(int score)
	{
		text.text = string.Format(format, score);
	}

}
