using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMoveController : MonoBehaviour
{
	public Rigidbody2D wheel;
	public float spinFactor;

	public void OnSpin(float power)
	{
		wheel.AddTorque(power * spinFactor, ForceMode2D.Force);
	}
}
