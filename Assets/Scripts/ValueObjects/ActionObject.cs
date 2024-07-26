using System;

namespace ValueObjects
{
	public class ActionObject<T> : ValueObject<Action<T>>
	{
		public void Invoke(T data)
		{
			if (_value != null)
			{
				_value.Invoke(data);
			}
		}

		public void AddListener(Action<T> listner)
		{
			_value += listner;
		}

		public void RemoveListener(Action<T> listner)
		{
			_value -= listner;
		}
    }
}

