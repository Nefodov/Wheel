using System;
using UnityEngine;

namespace ValueObjects
{
	[CreateAssetMenu(menuName = Constants.CREATE_MENU + "Action VoidObject")]
	public class ActionVoidObject : ValueObject<Action>
	{
		public void Invoke()
		{
			if (value != null)
			{
				value.Invoke();
			}
		}

		public void AddListener(Action listner)
		{
			value += listner;
		}

		public void RemoveListener(Action listner)
		{
			value -= listner;
		}
	}
}
