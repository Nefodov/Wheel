using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/MapItems/Level Object",order = 100)]
public class LevelObject : ScriptableObject
{
	public LevelData levelData;

	[ContextMenu("ToJson")]
	public void ToJson()
	{
		Debug.Log(JsonUtility.ToJson(levelData));
	}
}
