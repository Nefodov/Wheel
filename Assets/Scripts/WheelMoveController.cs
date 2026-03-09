using UnityEngine;
using ValueObjects;

public class WheelMoveController : MonoBehaviour
{
	public Rigidbody2D wheel;
	public FloatObject spinFactor;

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
		wheel.AddTorque(power * spinFactor.Value, ForceMode2D.Force);
	}
}
