using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using System;

namespace Map
{
	public class MapCreator : MonoBehaviour
	{
		[Expanded]
		public MapItem[] mapItems;

		[System.NonSerialized]
		private LevelData levelData;

		[Space]
		public LevelObject level;

		public LevelObject ovverideLevel;


		private void Awake()
		{
			levelData = ovverideLevel? ovverideLevel.levelData : level.levelData;
			Deserialize();
		}

		[ContextMenu("Deserialize")]
		public void Deserialize()
		{
			int count = levelData.serializeItems.Length;

			for (int i = 0; i < count; i++)
			{
				var data = levelData.serializeItems[i];
				int itemIndex = Array.FindIndex(mapItems, x => x.name == data.name);
				if (itemIndex >= 0) {
					var item = mapItems[itemIndex].FromJson(data.data);
					item.SetParent(this.transform);
				}
				else
				{
					Debug.LogErrorFormat("{0} are missing from Creator", levelData.serializeItems[i].name);
				}
			}
		}

		[ContextMenu("Serialize")]
		public void Serialize()
		{
			var shapes = GetComponentsInChildren<MapSceneItem>(true);

			int count = shapes.Length;
			levelData.serializeItems = new LevelData.SerializeItem[count];

			for (int i = 0; i < count; i++)
			{
				levelData.serializeItems[i].name = shapes[i].item.name;
				levelData.serializeItems[i].data = shapes[i].item.ToJson(shapes[i].gameObject);
			}
		}

		[ContextMenu("Save")]
		public void Save()
		{
			Serialize();
			ovverideLevel.levelData.serializeItems = levelData.serializeItems;
		}
	}
}
