using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
	public UnityEvent onEnable;

	public void OnEnable()
	{
		onEnable.Invoke();
	}
}
