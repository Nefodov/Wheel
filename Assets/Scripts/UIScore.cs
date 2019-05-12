using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ValueObjects;

public class UIScore : MonoBehaviour
{
	static readonly string format = "GoalsLeft: {0}";

	public TextMeshProUGUI text;
	public ActionIntObject onGoalsChange; 

	private void OnEnable()
	{
		onGoalsChange.AddListener(SetScore);
	}

	private void OnDisable()
	{
		onGoalsChange.RemoveListener(SetScore);
	}

	public void SetScore(int score)
	{
		text.text = string.Format(format, score);
	}

}
