using UnityEngine;

namespace ValueObjects
{
	public class ValueObject<T> : ValueObject
	{
		public T value;

		public override object RawValue()
		{
			return value;
		}
	}

	public abstract class ValueObject : ScriptableObject
	{
		public abstract object RawValue();
	}

	public class Constants
	{
		public const string CREATE_MENU = "Scriptable Objects/Values/";
	}
}
