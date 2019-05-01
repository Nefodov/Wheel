using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GroundCreator : MonoBehaviour
{
	public SpriteShapeController spriteShape;
	public TemplateItem[] items = new TemplateItem[0];

	[ContextMenu("Deserialize")]
	public void Deserialize()
	{
		int count = items.Length;

		for (int i = 0; i < count; i++)
		{
			var item = items[i].Deserialize(spriteShape);
			item.transform.SetParent(this.transform);
		}
	}

	[ContextMenu("Serialize")]
	public void Serialize()
	{
		var shapes = GetComponentsInChildren<SpriteShapeController>(true);

		int count = shapes.Length;
		items = new TemplateItem[count];
		for (int i = 0; i < count; i++)
		{
			items[i].Serialize(shapes[i]);
		}
	}

	[ContextMenu("To Json")]
	private void ToJson()
	{
		Debug.Log(JsonUtility.ToJson(this, true));
	}

	[ContextMenu("tojson")]
	private void tojson()
	{
		Debug.Log(JsonUtility.ToJson(this,false));
	}
}
