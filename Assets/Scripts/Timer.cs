using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[Expanded]
	public ValueObjects.FloatObject time;

	private bool update = false;

	public void RestartTimer()
	{
		time.Value = 0;
	}

	public void StartTimer()
	{
		time.Value = 0;
		update = true;
	}

	public void PauseTimer(bool state)
	{
		update = state;
	}

	public void Stop()
	{
		update = false;
	}

	public void Update()
	{
		if(update)
			time.Value += Time.deltaTime;
	}
}
