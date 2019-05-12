using UnityEngine;

namespace Map
{
	[System.Serializable]
	public class MapData<T> where T : Component
	{
		public Vector2 pos;
		public Quaternion rotation;

		public virtual T Deserialize(T prefab)
		{
			T spriteShape = Object.Instantiate<T>(prefab, pos, rotation);

			return spriteShape;
		}

		public virtual void Serialize(T target)
		{
			pos = target.transform.position;
			rotation = target.transform.rotation;
		}
	}
	
	public class MapData : MapData<Transform>
	{

	}
}