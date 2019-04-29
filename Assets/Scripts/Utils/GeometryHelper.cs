using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryHelper : MonoBehaviour
{
	public Transform p1;
	public Transform p2;
	public Transform p3;

	public float r = 0.1f;

	private void OnDrawGizmos()
	{
		DrawGizmos(false);
	}

	private void OnDrawGizmosSelected()
	{
		DrawGizmos(true);
	}

	private void DrawGizmos(bool selected)
	{
		Gizmos.DrawLine(p1.position, p2.position);
		Gizmos.DrawLine(p2.position, p3.position);

		Vector3 center = Vector3.Lerp(p1.position, p2.position, 0.5f);
		Vector3 subtracting = p1.position - p2.position;
		Vector3 cross = Vector3.Cross(subtracting, Vector3.forward);
		Vector3 result = center + cross;

		Vector3 center2 = Vector3.Lerp(p2.position, p3.position, 0.5f);
		Vector3 subtracting2 = p2.position - p3.position;
		Vector3 cross2 = Vector3.Cross(subtracting2, Vector3.forward);
		Vector3 result2 = center2 + cross2;


		Gizmos.DrawLine(center, result);
		Gizmos.DrawLine(center2, result2);

		bool found;
		Vector3 intersection = GetIntersectionPointCoordinates(center, result, center2, result2,out found);

		Gizmos.DrawSphere(intersection, r);
	}

	public Vector2 GetIntersectionPointCoordinates(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2, out bool found)
	{
		float tmp = (B2.x - B1.x) * (A2.y - A1.y) - (B2.y - B1.y) * (A2.x - A1.x);

		if (tmp == 0)
		{
			// No solution!
			found = false;
			return Vector2.zero;
		}

		float mu = ((A1.x - B1.x) * (A2.y - A1.y) - (A1.y - B1.y) * (A2.x - A1.x)) / tmp;

		found = true;

		return new Vector2(
			B1.x + (B2.x - B1.x) * mu,
			B1.y + (B2.y - B1.y) * mu
		);
	}



}
