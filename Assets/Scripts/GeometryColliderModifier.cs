using System.Collections.Generic;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;

namespace UnityEngine.U2D
{
    public struct GeometryColliderJob : IJob
    {
        public float2 scale;
        public NativeArray<float2> colliderData;

        public void Execute()
        {
            for (int i = 0; i < colliderData.Length; ++i)
            {
                var cd = colliderData[i];
                cd.x = cd.x * scale.x;
                cd.y = cd.y * scale.y;
                colliderData[i] = cd;
            }
        }
    }

    [CreateAssetMenu(fileName = "GeometryColliderModifier", menuName = "ScriptableObjects/GeometryColliderModifier", order = 1)]
    public class GeometryColliderModifier : SpriteShapeGeometryModifier
    {
        public float2 scale;

        public override JobHandle MakeModifierJob(JobHandle generator, SpriteShapeController spriteShapeController, NativeArray<ushort> indices, NativeSlice<Vector3> positions, NativeSlice<Vector2> texCoords, NativeSlice<Vector4> tangents, NativeArray<SpriteShapeSegment> segments, NativeArray<float2> colliderData)
        {
            if(spriteShapeController.TryGetComponent<EdgeCollider2D>(out var edgeCollider2D))
            {
                edgeCollider2D.edgeRadius = 0;
            }
            var mj = new GeometryColliderJob(){ colliderData = colliderData, scale = scale };
            var jh = mj.Schedule(generator);
            return jh;
        }
    }
}