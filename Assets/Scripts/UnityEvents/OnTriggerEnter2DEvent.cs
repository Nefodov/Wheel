using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnTriggerEnter2DEvent : MonoBehaviour
{
	public Collision2DEvent onTriggerEnter2D;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		onTriggerEnter2D.Invoke(collision);
	}
}
