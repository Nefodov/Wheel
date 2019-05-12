using System;

namespace ValueObjects
{
	public class ActionObject<T> : ValueObject<Action<T>>
	{
		public void Invoke(T data)
		{
			if (value != null)
			{
				value.Invoke(data);
			}
		}

		public void AddListener(Action<T> listner)
		{
			value += listner;
		}

		public void RemoveListener(Action<T> listner)
		{
			value -= listner;
		}
	}
}

