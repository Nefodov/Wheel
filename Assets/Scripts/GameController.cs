﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameControllerInterface controllerInterface;

	private void Awake()
	{
		Application.targetFrameRate = 60;
		controllerInterface.Restart();
	}
}