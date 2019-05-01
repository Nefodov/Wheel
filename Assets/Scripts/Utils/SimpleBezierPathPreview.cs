using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBezierPathPreview : MonoBehaviour {

	public Transform point1;
	public Transform point2;
	public Transform point3;
	[Range(0,1)]
	public float range;

	private void OnDrawGizmos()
	{
		Vector3[] points = new Vector3[20];
		Vector3 point = new Vector3();

		if (point1 && point2)
		{
			//Get Line
			SimpleBezierPath.GetPath(transform.position, point1.position, point2.position, ref points);
			SimpleBezierPath.DebugDrawPath(points);

			//Get Single Point
			SimpleBezierPath.CalculateBezierPoint(range, transform.position, point1.position, point2.position, ref point);
			Gizmos.DrawSphere(point,1f);
		}

		if (point1 && point2 && point3)
		{
			//Get Line
			SimpleBezierPath.GetPath(transform.position, point1.position, point2.position, point3.position, ref points);
			SimpleBezierPath.DebugDrawPath(points);

			//Get Single Point
			SimpleBezierPath.CalculateBezierPoint(range, transform.position, point1.position, point2.position, point3.position, ref point);
			Gizmos.DrawSphere(point, 1f);
		}
	}

}

public class SimpleBezierPath
{

#region 3 Points
	/// <summary>
	/// 3 Points Bezier Path
	/// </summary>
	/// <param name="p0">First Point</param>
	/// <param name="p1">Second Point</param>
	/// <param name="p2">Third Point</param>
	/// <param name="points">Path Array</param>
	public static void GetPath(Vector3 p0, Vector3 p1, Vector3 p2, ref Vector3[] points)
	{
		int count = points.Length;
		for (int j = 0; j < count; j++)
		{
			float r = j / (float)(count - 1);
			CalculateBezierPoint(r, p0, p1, p2, ref points[j]);
		}
	}
	/// <summary>
	/// Evaluate Point on 3 Points Bezier Path
	/// </summary>
	/// <param name="r">Range from 0f to 1f</param>
	/// <param name="p0">First Point</param>
	/// <param name="p1">Second Point</param>
	/// <param name="p2">Third Point</param>
	/// <param name="point">Evaluated Point</param>
	public static void CalculateBezierPoint(float r, Vector3 p0, Vector3 p1, Vector3 p2, ref Vector3 point)
	{
		float t1 = 1 - r;
		point.x = t1 * t1 * p0.x + 2 * r * t1 * p1.x + r * r * p2.x;
		point.y = t1 * t1 * p0.y + 2 * r * t1 * p1.y + r * r * p2.y;
	}

	#endregion

	#region 4 Points
	/// <summary>
	/// 4 Points Bezier Path
	/// </summary>
	/// <param name="p0">First Point</param>
	/// <param name="p1">Second Point</param>
	/// <param name="p2">Third Point</param>
	/// <param name="p3">Fourth Point</param>
	/// <param name="points">Path Array</param>
	public static void GetPath(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, ref Vector3[] points)
	{
		int count = points.Length;
		for (int j = 0; j < count; j++)
		{
			float r = j / (float)(count - 1);
			CalculateBezierPoint(r, p0, p1, p2,p3, ref points[j]);
		}
	}
	/// <summary>
	/// Evaluate Point on 4 Points Bezier Path
	/// </summary>
	/// <param name="r">Range from 0f to 1f</param>
	/// <param name="p0">First Point</param>
	/// <param name="p1">Second Point</param>
	/// <param name="p2">Third Point</param>
	/// <param name="p3">Fourth Point</param>
	/// <param name="point">Evaluated Point</param>
	public static void CalculateBezierPoint(float r, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, ref Vector3 point)
	{
		float t1 = 1 - r;
		point.x = t1 * t1 * t1 * p0.x + 3 * r * t1 * t1 * p1.x + 3 * r * r * t1 * p2.x + r * r * r * p3.x;
		point.y = t1 * t1 * t1 * p0.y + 3 * r * t1 * t1 * p1.y + 3 * r * r * t1 * p2.y + r * r * r * p3.y;
	}

#endregion
	public static void DebugDrawPath(Vector3[] points)
	{
		for (int i = 0; i < points.Length - 1; i++)
		{
			Debug.DrawLine(points[i], points[i + 1], Color.Lerp(Color.red, Color.green, i % 2));
		}
	}

}


