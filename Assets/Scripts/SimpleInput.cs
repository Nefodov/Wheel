using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ValueObjects;

public class SimpleInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Slider slider;
	public ActionFloatObject eventObject;

	public float k;
	bool active;

	private void OnDisable()
	{
		OnPointerUp(null);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		active = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		active = false;
		slider.value = 0;
	}

	private void FixedUpdate()
	{
		if (active)
		{
			eventObject.Invoke(slider.value * k);
		}
	}
}
