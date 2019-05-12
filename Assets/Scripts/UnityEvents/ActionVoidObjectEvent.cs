using UnityEngine;
using UnityEngine.Events;
using ValueObjects;

public class ActionVoidObjectEvent : MonoBehaviour
{
	public ActionVoidObject action;
	public UnityEvent unityEvent;

	private void Awake()
	{
		action.AddListener(unityEvent.Invoke);
	}

	private void OnDestroy()
	{
		action.RemoveListener(unityEvent.Invoke);
	}
}
