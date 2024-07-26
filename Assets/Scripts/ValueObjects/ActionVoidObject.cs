using System;
using UnityEngine;

namespace ValueObjects
{
	[CreateAssetMenu(menuName = Constants.CREATE_MENU_ACTION + "Action VoidObject")]
	public class ActionVoidObject : ValueObject<Action>
	{
		public void Invoke()
		{
            _value?.Invoke();
        }

		public void AddListener(Action listener)
		{
			_value += listener;
		}

		public void RemoveListener(Action listener)
		{
			_value -= listener;
		}
    }
}
