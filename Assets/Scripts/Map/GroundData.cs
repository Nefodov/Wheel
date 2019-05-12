using UnityEngine;
using UnityEngine.U2D;

namespace Map
{
	[System.Serializable]
	public class GroundData : MapData<SpriteShapeController>
	{
		public Point[] points;

		[System.Serializable]
		public struct Point
		{
			/// <summary>
			/// Positon
			/// </summary>
			public Vector2 pos;
			public ShapeTangentMode tm;
			/// <summary>
			/// Left Tangent
			/// </summary>
			public Vector2 lt;
			/// <summary>
			/// Right Tangent
			/// </summary>
			public Vector2 rt;
		}

		public override SpriteShapeController Deserialize(SpriteShapeController prefab)
		{
			var spriteShape = base.Deserialize(prefab);
			Spline s = spriteShape.spline;

			s.Clear();

			int count = points.Length;

			for (int i = 0; i < count; i++)
			{
				s.InsertPointAt(i, points[i].pos);
				s.SetTangentMode(i, points[i].tm);
				s.SetLeftTangent(i, points[i].lt);
				s.SetRightTangent(i, points[i].rt);
			}
			spriteShape.BakeCollider();

			return spriteShape;
		}

		public override void Serialize(SpriteShapeController target)
		{
			base.Serialize(target);

			Spline s = target.spline;

			int count = s.GetPointCount();

			points = new Point[count];
			for (int i = 0; i < count; i++)
			{
				points[i].pos = s.GetPosition(i);
				points[i].tm = s.GetTangentMode(i);
				points[i].lt = s.GetLeftTangent(i);
				points[i].rt = s.GetRightTangent(i);
			}
		}
	}
}
