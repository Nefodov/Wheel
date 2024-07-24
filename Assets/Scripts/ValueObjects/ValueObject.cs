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
		public const string CREATE_MENU = "ScriptableObjects/Values/";
		public const string CREATE_MENU_CONST = "ScriptableObjects/Values/Const/";
		public const string CREATE_MENU_ACTION = "ScriptableObjects/Values/Action/";

    }
}
