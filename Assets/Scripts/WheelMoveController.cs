using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueObjects;

public class WheelMoveController : MonoBehaviour
{
	public Rigidbody2D wheel;
	public float spinFactor;

	public ActionFloatObject eventObject;

	public void Awake()
	{
		eventObject.AddListener(OnSpin);
	}
	private void OnDestroy()
	{
		eventObject.RemoveListener(OnSpin);
	}

	public void OnSpin(float power)
	{
		wheel.AddTorque(power * spinFactor, ForceMode2D.Force);
	}
}
