using UnityEngine;

namespace ValueObjects
{
    public abstract class ValueObject<T> : ValueObjectBase
	{
        public virtual T Value { get; set; }
    }

	public abstract class ValueObjectBase : ScriptableObject
	{
		public abstract object RawValue();
	}

	public class Constants
	{
		public const string CREATE_MENU = "Scriptable Objects/Values/";
	}
}
