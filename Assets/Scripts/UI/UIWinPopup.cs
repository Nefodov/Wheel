using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ValueObjects;

public class UIWinPopup : MonoBehaviour
{
	public LevelObject level;
	public FloatObject time;

	public string goalsFormat = "{0}/{1}";
	public IntObject goalsLeft;
	public IntObject goalsTotal;

	public TextMeshProUGUI currentScore;
	public TextMeshProUGUI[] scores;

	public string timeFormat= "0.00";
	public TextMeshProUGUI currentTime;
	public TextMeshProUGUI[] times;

	public void UpdateData()
	{
		int collected = goalsTotal.Value - goalsLeft.Value;
		currentScore.text = string.Format(goalsFormat, collected, goalsTotal.Value);
		int length = scores.Length;
		for (int i = 0; i < length; i++)
		{
			int ceil = Mathf.CeilToInt(goalsTotal.Value * level.levelData.percents[i]);
			scores[i].text = ceil.ToString();
		}

		currentTime.text = time.Value.ToString(timeFormat);
		length = times.Length;
		for (int i = 0; i < length; i++)
		{
			times[i].text = level.levelData.times[i].ToString(timeFormat);
		}
	}
}
