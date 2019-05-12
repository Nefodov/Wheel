using UnityEngine;

namespace Map
{
	public class MapItem<T1, T2> : MapItem
		where T1 : Component
		where T2 : MapData<T1>, new()
	{
		public T1 prefab;

		public override Transform FromJson(string json)
		{
			var data = JsonUtility.FromJson<T2>(json);
			return data.Deserialize(prefab).transform;
		}

		public override string ToJson(GameObject target)
		{
			var component = target.GetComponent<T1>();

			var data = new T2();
			data.Serialize(component);
			return JsonUtility.ToJson(data);
		}
	}

	public abstract class MapItem : ScriptableObject
	{
		public abstract Transform FromJson(string json);
		public abstract string ToJson(GameObject target);
	}
}
