﻿using System;
using UnityEngine;

namespace ValueObjects
{
    public abstract class ValueObject<T> : ValueObjectBase
	{
        protected T _value;
        public virtual T Value
        {
            get => _value;

            set
            {
                T oldValue = Value;
                _value = value;

                onValueChanged?.Invoke(oldValue, value);
            }
        }

        protected Action<T, T> onValueChanged;

        public override object RawValue() => _value;
        public override void Reset() 
        {
            onValueChanged = null;
            Value = default;
        }

        /// <summary>
        /// <c>&lt;<typeparamref name="T"/> oldValue, <typeparamref name="T"/> newValue&gt;</c>
        /// </summary>
        public event Action<T, T> OnValueChanged
        {
            add
            {
                value?.Invoke(Value, Value);
                onValueChanged += value;
            }
            remove
            {
                onValueChanged -= value;
            }
        }
    }

	public abstract class ValueObjectBase : ScriptableObject
	{
		public abstract object RawValue();
		public abstract void Reset();
	}

	public class Constants
	{
		public const string CREATE_MENU = "ScriptableObjects/Values/";
		public const string CREATE_MENU_CONST = "ScriptableObjects/Values/Const/";
		public const string CREATE_MENU_ACTION = "ScriptableObjects/Values/Action/";
    }
}
