using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public LevelObject level;
	
	public void SetLevel(LevelObject level)
	{
		this.level.levelData = level.levelData;
	}

    public void LoadGameScene()
    {
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
}
