using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MathHelper : MonoBehaviour
{
	public Transform from;
	public Transform to;

	public float angle;

	public void Update()
	{
		if (from != null && to != null)
		{
			Debug.DrawLine(transform.position, from.position);
			Debug.DrawLine(from.position, to.position);
			Debug.DrawLine(to.position, transform.position);

			angle = AngleBetweenVector2(from.localPosition, to.localPosition);

		}
	}

	private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
	{
		Vector2 diference = vec2 - vec1;
		return Vector2.SignedAngle(vec1, vec2);
	}
}
