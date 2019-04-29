using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Rigidbody2D wheel;
	public int tailSize;

	public bool debugPoints;


	ArrayPool<Vector3> tail_position;
	ArrayPool<Vector2> tail_velocity;

	private bool active;

	public void OnPointerDown(PointerEventData eventData)
	{
		active = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		active = false;
	}

	private void Awake()
	{
		tail_position = new ArrayPool<Vector3>(tailSize);
		tail_velocity = new ArrayPool<Vector2>(tailSize);
	}

	void Update()
	{
		if (active)
		{
			if (tail_position.Count > 0)
			{
				wheel.position = tail_position[0];
				wheel.velocity = tail_velocity[0];
				tail_position.Remove();
				tail_velocity.Remove();
			}
		}
		else
		{
			tail_position.Add(wheel.position);
			tail_velocity.Add(wheel.velocity);
		}

		if (debugPoints)
		{
			for (int i = 0; i < tail_position.Count; i++)
			{
				Debug.DrawLine(tail_position[i], tail_position[i + 1]);
			}
		}
	}
}
