using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using ValueObjects;

public class SpinInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[System.Serializable] public class SpinEvent : UnityEvent<float> { }

	public SpinType spinType;
	public GameObject inputWheel;

	public ActionFloatObject onSpin;

	public float maxAngle = Vector2.kEpsilon;

	private bool active;
	public Vector2 startPosition;
	public Vector2 previousPosition;
	public Vector2 thirdPosition;
	
	public ArrayPool<Vector3> tail = new ArrayPool<Vector3>(4);

	private Vector2 minX, minY, maxX, maxY;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!active)
		{
			EnableWheel(eventData.pressPosition);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (active)
		{
			DisableWheel();
		}
	}

	private void EnableWheel(Vector2 pressPosition)
	{
		active = true;
		startPosition = pressPosition;
		previousPosition = Vector3.zero;
		thirdPosition = previousPosition;
		inputWheel.transform.position = startPosition;
		inputWheel.SetActive(true);
		tail.Reset();
	}

	private void DisableWheel()
	{
		active = false;
		inputWheel.SetActive(false);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (active)
		{
			if (spinType == SpinType.FixedPoint)
			{
				FixedPointSpin(eventData);
			}
			if(spinType == SpinType.DynamicPoint)
			{
				DynamicPointSpin(eventData);
			}
		}
	}

	private void FixedPointSpin(PointerEventData eventData)
	{
		Debug.DrawLine(startPosition, eventData.position);

		var currentPos = eventData.position - startPosition;
		float angle = Vector2.SignedAngle(previousPosition, currentPos);
		previousPosition = currentPos;

		inputWheel.transform.Rotate(Vector3.forward, angle, Space.Self);
		onSpin.Invoke(angle / 360f);
	}

	private void DynamicPointSpin(PointerEventData eventData)
	{
		tail.Add(eventData.position);

		//Debug.DrawLine(startPosition, eventData.position);

		var currentPos = eventData.position - startPosition;
		float angle = Vector2.SignedAngle(previousPosition, currentPos);

		thirdPosition = previousPosition;
		previousPosition = currentPos;


		var newPos = Center(thirdPosition, previousPosition, currentPos);
		inputWheel.transform.position = new Vector3(newPos.x + startPosition.x, newPos.y + startPosition.y, 0) ;

		inputWheel.transform.Rotate(Vector3.forward, angle, Space.Self);
		onSpin.Invoke(angle / 360f);
	}

	private void LateUpdate()
	{
		//DrawTail();
		//DrawBezier();
	}

	private void DrawTail()
	{
		var count = tail.Count;

		for (int i = 0; i < count-2; i+=2)
		{
			Debug.DrawLine(tail[i], tail[i + 1]);
			Debug.DrawLine(tail[i+1], tail[i + 2]);
			var center = Center(tail[i], tail[i + 1], tail[i + 2]);
			Debug.DrawLine(tail[i], center);
			//Debug.DrawLine(tail[i+1], center);
		}

	}

	Vector3[] bezierPath = new Vector3[3];
	private void DrawBezier()
	{
		if (tail.Count > 3) {
			SimpleBezierPath.GetPath(tail[0], tail[1], tail[2], tail[3], ref bezierPath);
		}else if (tail.Count > 2)
		{
			SimpleBezierPath.GetPath(tail[0], tail[1], tail[2], ref bezierPath);
		}
		SimpleBezierPath.DebugDrawPath(bezierPath);
	}


	private Vector3 Center(Vector3 p1,Vector3 p2, Vector3 p3)
	{
		Vector3 center = Vector3.Lerp(p1, p2, 0.5f);
		Vector3 subtracting = p1 - p2;
		Vector3 cross = Vector3.Cross(subtracting, Vector3.forward);
		Vector3 result = center + cross;

		Vector3 center2 = Vector3.Lerp(p2, p3, 0.5f);
		Vector3 subtracting2 = p2 - p3;
		Vector3 cross2 = Vector3.Cross(subtracting2, Vector3.forward);
		Vector3 result2 = center2 + cross2;

		bool found;
		Vector3 intersection = GetIntersectionPointCoordinates(center, result, center2, result2, out found);

		return intersection;
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


	public enum SpinType
	{
		FixedPoint,
		DynamicPoint
	}
}
