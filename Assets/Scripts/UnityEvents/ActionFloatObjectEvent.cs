using UnityEngine;
using UnityEngine.Events;
using ValueObjects;

public class ActionFloatObjectEvent : MonoBehaviour
{
	public ActionFloatObject action;
	public UnityEvent<float> unityEvent;

	private void Awake()
	{
		action.AddListener(unityEvent.Invoke);
	}

	private void OnDestroy()
	{
		action.RemoveListener(unityEvent.Invoke);
	}
}
