// A simple C# job to generate a quad.
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace UnityEngine.U2D
{
    public struct ColorCreatorJob : IJob
    {
        // Indices of the generated triangles.
        public NativeArray<ushort> indices;
        // Vertex positions.
        public NativeSlice<Vector3> positions;
        // Texture Coordinates.
        public NativeSlice<Vector2> texCoords;
        // Color of Vertices.
        public NativeSlice<Color32> colors;
        // Sub-meshes of generated geometry.
        public NativeArray<UnityEngine.U2D.SpriteShapeSegment> segments;
        // Input Bounds.
        public Bounds bounds;

        public void Execute()
        {
            // Generate Positions/TexCoords/Indices for the Quad.
            positions[0] = bounds.min;
            texCoords[0] = Vector2.zero;
            //colors[0] = Color.red;
            positions[1] = bounds.max;
            texCoords[1] = Vector2.one;
            //colors[1] = Color.blue;
            positions[2] = new Vector3(bounds.min.x, bounds.max.y, 0);
            texCoords[2] = new Vector2(0, 1);
            //colors[2] = Color.green;
            positions[3] = new Vector3(bounds.max.x, bounds.min.y, 0);
            texCoords[3] = new Vector2(1, 0);
            //colors[3] = Color.yellow;
            indices[0] = indices[3] = 0;
            indices[1] = indices[4] = 1;
            indices[2] = 2;
            indices[5] = 3;

            // Set the only sub-mesh (quad)
            var seg = segments[0];
            seg.geomIndex = seg.spriteIndex = 0;
            seg.indexCount = 6;
            seg.vertexCount = 4;
            segments[0] = seg;

            // Reset other sub-meshes.
            seg.geomIndex = seg.indexCount = seg.spriteIndex = seg.vertexCount = 0;
            for (int i = 1; i < segments.Length; ++i)
                segments[i] = seg;
        }
    }

    [CreateAssetMenu(fileName = "SpriteShapeColorQuad", menuName = "ScriptableObjects/SpriteShapeColorQuad", order = 1)]
    public class SpriteShapeColorQuad : SpriteShapeGeometryCreator
    {
        public Color32[] c1;
        public override int GetVertexArrayCount(SpriteShapeController sc)
        {
            return 64;
        }

        public override JobHandle MakeCreatorJob(SpriteShapeController sc,
            NativeArray<ushort> indices, NativeSlice<Vector3> positions, NativeSlice<Vector2> texCoords,
            NativeSlice<Vector4> tangents, NativeArray<UnityEngine.U2D.SpriteShapeSegment> segments, NativeArray<float2> colliderData)
        {
            NativeArray<Bounds> bounds = sc.spriteShapeRenderer.GetBounds();
            var spline = sc.spline;
            int pointCount = spline.GetPointCount();
            Bounds bds = new Bounds(spline.GetPosition(0), spline.GetPosition(0));
            for (int i = 0; i < pointCount; ++i)
                bds.Encapsulate(spline.GetPosition(i));

            NativeSlice<Color32> colors = default(NativeSlice<Color32>);
            sc.spriteShapeRenderer.GetChannels(32000, out indices, out positions, out texCoords, out colors);

            colors[0] = c1[0];
            colors[1] = c1[1];
            colors[2] = c1[2];
            colors[3] = c1[3];
            
            var cj = new ColorCreatorJob()
            { indices = indices, positions = positions, texCoords = texCoords, colors = colors, segments = segments, bounds = bds};
            var jh = cj.Schedule();
            return jh;
        }

    }
}