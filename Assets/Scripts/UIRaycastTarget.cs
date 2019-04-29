using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRaycastTarget : Graphic, ICanvasRaycastFilter
{
	[SerializeField]
	private string text;
	public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
	{
		if(!enabled)
			return false;

		Vector2 local;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, eventCamera, out local))
			return false;

		return true;
	}
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
	}

	private void OnDrawGizmos()
	{
		if (enabled)
		{
			Vector3[] corners = new Vector3[4];
			rectTransform.GetWorldCorners(corners);

			var _color = Gizmos.color;
			Gizmos.color = color;
			for(int i = 0; i < 4; i++)
			{
				for(int j = i + 1; j < 4; j++)
				{
					var c1 = RectTransformUtility.WorldToScreenPoint(Camera.main, corners[i]);
					var c2 = RectTransformUtility.WorldToScreenPoint(Camera.main, corners[j]);
					Gizmos.DrawLine(c1, c2);
				}
			}
			Gizmos.color = _color;
		}
	}
}
