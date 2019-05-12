using UnityEngine;

[System.Serializable]
public struct LevelData
{
	public float[] times;
	[Range(0f,1f)]
	public float[] percents;
	public SerializeItem[] serializeItems;

	[System.Serializable]
	public struct SerializeItem
	{
		public string name; //ScriptableObject
		public string data; //Json
	}
}
